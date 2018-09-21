using System;
using TodoApi.Models;

namespace TodoApi.Services
{
    public interface IBreedService
    {
        Breed Get(int id);
    }
}
