using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;

namespace Business.Services
{
    public interface IDirectorService
    {
        IQueryable<DirectorModel> Query();
    }
    public class DirectorService
    {
        private readonly Db db;
    }
}
