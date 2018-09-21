using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface IBreedService
    {
        Breed Get(int id);
        List<Breed> Get();
        void Add(Breed b);
        void Edit(Breed b);
        void Delete(int id);
    }
}
