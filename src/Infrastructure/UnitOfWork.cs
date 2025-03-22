using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public AdminRepository AdminRepository { get; }
        public CategoryRepository CategoryRepository { get; }
        public ProjectRepository ProjectRepository { get; }
        public WebProfileRepository WebProfileRepository { get; }

        public UnitOfWork(
            AppDbContext context, 
            AdminRepository adminRepository, 
            CategoryRepository categoryRepository, 
            ProjectRepository projectRepository,
            WebProfileRepository webProfileRepository)
        {
            _context = context;
            AdminRepository = adminRepository;
            CategoryRepository = categoryRepository;
            ProjectRepository = projectRepository;
            WebProfileRepository = webProfileRepository;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                }
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }
    }
}