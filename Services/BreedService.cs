using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.DapperUnitOfWork;
using TodoApi.Models;

namespace TodoApi.Services
{
    public class BreedService : IBreedService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BreedService(IUnitOfWork UnitOfWork)
        {
            this._unitOfWork = UnitOfWork;
        }

        public Breed Get(int id)
        {
            return _unitOfWork.BreedRepository.Find(id);
        }      

        public List<Breed> Get()
        {
            return _unitOfWork.BreedRepository.All().ToList();
        }

        public void Add(Breed b)
        {
            _unitOfWork.BreedRepository.Add(b);
            _unitOfWork.Commit();
        }

        public void Edit(Breed b)
        {
            _unitOfWork.BreedRepository.Update(b);
            _unitOfWork.Commit();
        }
        public void Delete(int id)
        {
            _unitOfWork.BreedRepository.Delete(id);
            _unitOfWork.Commit();
        }
          // Breed r = new Breed(); 
            // string conn = "Data Source=10.0.2.15,1401;Initial Catalog=CYMoto;Persist Security Info=True;User ID=sa;Password=gary156*;MultipleActiveResultSets=True";
            // using (var uow = new UnitOfWork())
            // {
            //     r = uow.BreedRepository.Find(id);
                
            //     // var orangeMackerel = uow.BreedRepository.FindByName("Orange Mackerel");
            //     // var morris = new Cat { BreedId = orangeMackerel.BreedId, Name = "Morris", Age = 12 };
            //     // uow.CatRepository.Add(morris);
            //     // uow.Commit();

            //     // var siamese = new Breed { Name = "Siamese" };
            //     // uow.BreedRepository.Add(siamese);
            //     // var foo = new Cat { BreedId = siamese.BreedId, Name = "Foo", Age = 19 };
            //     // var xing = new Cat { BreedId = siamese.BreedId, Name = "Xing", Age = 6 };
            //     // var xang = new Cat { BreedId = siamese.BreedId, Name = "Xang", Age = 6 };
            //     // uow.CatRepository.Add(foo);
            //     // uow.CatRepository.Add(xing);
            //     // uow.CatRepository.Add(xang);
            //     // uow.Commit();
            // }
            // // return new string[] { r.BreedId.ToString(), r.Name}; 
            // return r.Name;
    }
}
