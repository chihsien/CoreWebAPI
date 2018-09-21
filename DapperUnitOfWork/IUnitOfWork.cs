using TodoApi.Repositories;
using System;

namespace TodoApi.DapperUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBreedRepository BreedRepository { get; }
        ICatRepository CatRepository { get; }

        void Commit();
    }
}