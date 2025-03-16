﻿using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public sealed class UnitOfWork : IDisposable
    {
        private readonly AppDbContext _context;

        private IDbContextTransaction _transaction;
        public AdminRepository AdminRepository { get; }
        public CategoryRepository CategoryRepository { get; }
        public ProjectRepository ProjectRepository { get; }

        public UnitOfWork(
            AppDbContext context,
            CategoryRepository categoryRepository,
            ProjectRepository projectRepository,
            AdminRepository adminRepository)
        {
            _context = context;
            CategoryRepository = categoryRepository;
            ProjectRepository = projectRepository;
            AdminRepository = adminRepository;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction ??= await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction not started.");

            try
            {
                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch (Exception)
            {
                await RollbackTransactionAsync();
                throw;
            }

        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public async Task RollbackTransactionAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("Transaction not started.");

            await _transaction.RollbackAsync();
        }
    }
}