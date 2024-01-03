using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services
{
    public interface IDirectorService
    {
        IQueryable<DirectorModel> Query();
        bool Add(DirectorModel model);
        bool Update(DirectorModel model);
        bool Delete(int id);
    }
    public class DirectorService : IDirectorService
    {
        private readonly Db _db;

        public DirectorService(Db db) {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool Add(DirectorModel model)
        {
            if (_db.Directors.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim()))
            {
                return false;
            }

            Director newDirector = new Director()
            {

                Id = model.Id,
                Name = model.Name,
                Surname = model.Surname,
                BirthDate = model.BirthDate,
                IsRetired = model.IsRetired
            };

            _db.Directors.Add(newDirector);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Director toDelete = _db.Directors.Include(d => d.Movies).SingleOrDefault(s => s.Id == id);

            if (toDelete is null)
            {
                return false;
            }

            if (toDelete.Movies.Any())
            {
                return false;
            }

            _db.Directors.Remove(toDelete);
            _db.SaveChanges();

            return true;
        }

        public IQueryable<DirectorModel> Query()
        {
            return _db.Directors.OrderBy(a => a.Id).Select(a => new DirectorModel()
            {
                Name = a.Name,
                Surname = a.Surname,
                BirthDate = a.BirthDate,
                IsRetired = a.IsRetired,
                Id = a.Id
            });
        }

        public bool Update(DirectorModel model)
        {
            if (_db.Directors.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim() && s.Id != model.Id))
            {
                return false;
            }
            Director existingEntity = _db.Directors.SingleOrDefault(s => s.Id == model.Id);
            if (existingEntity is null)
            {
                return false;
            }
            existingEntity.Id = model.Id;
            existingEntity.Name = model.Name.Trim();
            existingEntity.Surname = model.Surname;
            existingEntity.BirthDate = model.BirthDate;
            existingEntity.IsRetired = model.IsRetired;
            _db.Directors.Update(existingEntity);
            _db.SaveChanges();
            return true;
        }
    }
}
