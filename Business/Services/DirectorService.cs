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
    public class DirectorService : IDirectorService
    {
        private readonly Db _db;

        public DirectorService(Db db) {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        public IQueryable<DirectorModel> Query()
        {
            return _db.Directors.OrderBy(a => a.BirthDate).Select(a => new DirectorModel()
            {
                Name = a.Name,
                Surname = a.Surname,
                BirthDate = a.BirthDate,
                IsRetired = a.IsRetired
            });
        }
    }
}
