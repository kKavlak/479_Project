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
        IQueryable<MovieGenre> Query();
    }
    public class MovieService
    {
        private readonly Db db;
    }
}
