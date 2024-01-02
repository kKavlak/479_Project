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
    public class GenreService
    {
        private readonly Db db;
    }
}
