using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using DataAccess.Contexts;



namespace Business.Services
{
    public interface IGenreService
    {
        IQueryable<GenreModel> Query();
    }
    public class GenreService : IGenreService
    {
        private readonly Db _db;

        public GenreService(Db db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IQueryable<GenreModel> Query()
        {
            return _db.Genres.Select(a => new GenreModel()
            {
                Name = a.Name
            });
        }
    }
}
