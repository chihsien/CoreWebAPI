using TodoApi.Repositories;
using System;
using System.Data;
using System.Data.SqlClient;  // It's for MSSQL 
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace TodoApi.DapperUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IBreedRepository _breedRepository;
        private ICatRepository _catRepository;
        private bool _disposed;

        private readonly IConfiguration _config;

        // public UnitOfWork(string connectionString)
        public UnitOfWork(IConfiguration config)
        {
            _config = config;

            // It's for MSSQL Connection
            // string connectionString = _config["ConnectionStrings:SqlConn"];
            // _connection = new SqlConnection(connectionString);

            // It's for Mysql Connection
            string connectionString = _config["ConnectionStrings:MySqlConn"];            
            _connection = new MySqlConnection(connectionString);

            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public IBreedRepository BreedRepository
        {
            get { return _breedRepository ?? (_breedRepository = new BreedRepository(_transaction)); }
        }

        public ICatRepository CatRepository
        {
            get { return _catRepository ?? (_catRepository = new CatRepository(_transaction)); }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = _connection.BeginTransaction();
                resetRepositories();
            }
        }

        private void resetRepositories()
        {
            _breedRepository = null;
            _catRepository = null;
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    if (_transaction != null)
                    {
                        _transaction.Dispose();
                        _transaction = null;
                    }
                    if(_connection != null)
                    {
                        _connection.Dispose();
                        _connection = null;
                    }
                }
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
