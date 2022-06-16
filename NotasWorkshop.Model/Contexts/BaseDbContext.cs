﻿using System;
using System.Threading;
using System.Threading.Tasks;
using NotasWorkshop.Core.BaseModel.BaseEntity;
using NotasWorkshop.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Options;
using NotasWorkshop.Model.Entities;

namespace NotasWorkshop.Model.Contexts
{
    public abstract class BaseDbContext : DbContext
    {
        private readonly string? _userEmail;
        private readonly AppSettings? _appSettings;
        public BaseDbContext(DbContextOptions options, IOptions<AppSettings>? appSettings = null) : base(options)
        {
            _appSettings = appSettings?.Value;
        }

        /// <summary>
        /// Nos dice que sucede segun las acciones de SQL
        /// </summary>
        private void SetAuditEntities()
        {
            foreach (var entry in ChangeTracker.Entries<IBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        if (entry.Entity.Id > 0)
                        {
                            entry.State = EntityState.Modified;
                            goto case EntityState.Modified;
                        }

                        entry.Entity.Deleted = false;
                        entry.Entity.CreatedBy = _userEmail;
                        if (!entry.Entity.CreatedDate.HasValue)
                            entry.Entity.CreatedDate = DateTimeOffset.Now;
                        break;
                    case EntityState.Modified:
                        entry.Property(x => x.CreatedDate).IsModified = false;
                        entry.Property(x => x.CreatedBy).IsModified = false;
                        entry.Entity.UpdatedDate = DateTimeOffset.Now;
                        entry.Entity.UpdatedBy = _userEmail;

                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.Deleted = true;
                        goto case EntityState.Modified;

                    default:
                        goto case EntityState.Modified;
                }
            }
        }

        #region Definiendo los guardados dentro de la aplicacion

        private async Task<int> BeforeSaveAsync(Func<Task<int>> action)
        {
            SetAuditEntities();
            return await action.Invoke();
        }
        private int BeforeSave(Func<int> action)
        {
            SetAuditEntities();
            return action.Invoke();
        }
        public override int SaveChanges()
        {
            return BeforeSave(() => base.SaveChanges());
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            return BeforeSave(() => base.SaveChanges(acceptAllChangesOnSuccess));
        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await BeforeSaveAsync(() => base.SaveChangesAsync(cancellationToken));
        }
        #endregion

        public override ChangeTracker ChangeTracker => base.ChangeTracker;

        // Definiendo que pasa durante la creacion de un modelo

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarberProfile>()
            .HasOne(b => b.User)
            .WithOne(p => p.BarberProfiles)
            .OnDelete(DeleteBehavior.ClientCascade);
            
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                //if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
                //    modelBuilder.SetSoftDeleteFilter(type.ClrType);
            }
        }
    }
}
