using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IMovieService
    {
        IQueryable<MovieModel> Query();

        bool Add(MovieModel model);

        bool Update(MovieModel model);

        bool Delete(int id);
    }
    public class MovieService : IMovieService
    {
        private readonly Db _db;
        public MovieService(Db db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public bool Add(MovieModel model)
        {
            if (_db.Movies.Any(x => x.Name.ToUpper() == model.Name.ToUpper().Trim()))
            {
                return false;
            }

            Movie newmovie = new Movie()
            {

                Id = model.MovieId,
                Name = model.Name,
                Revenue = model.Revenue,
                Year = model.Year,
                DirectorId = model.DirectorId,
            };

            _db.Movies.Add(newmovie);
            _db.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            Movie toDelete = _db.Movies.SingleOrDefault(s => s.Id == id);
            if (toDelete is null)
            {
                return false;
            }
            _db.Movies.Remove(toDelete);
            _db.SaveChanges();
            return true;
        }

        public IQueryable<MovieModel> Query()
        {
            return _db.Movies.OrderBy(a => a.MovieId).Select(a => new MovieModel()
            {
                MovieId = a.MovieId,
                DirectorId = a.DirectorId,
                Revenue = a.Revenue,
                Name = a.Name,
                Year = a.Year
            });
        }

        public bool Update(MovieModel model)
        {
            if (_db.Movies.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim() && s.Id != model.MovieId))
            {
                return false;
            }
            Movie current = _db.Movies.SingleOrDefault(s => s.Id == model.MovieId);
            if (current is null)
            {
                return false;
            }
            current.Id = model.MovieId;
            current.Name = model.Name.Trim();
            current.Year = model.Year;
            current.Revenue = model.Revenue;
            current.DirectorId = model.DirectorId;
            _db.Movies.Update(current);
            _db.SaveChanges();
            return true;
        }
    }
}
