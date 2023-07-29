using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.IRepository;
using Kombox.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kombox.DataAccess.Repository
{
    public class ApplicationUserRepository: Repository<ApplicationUser>, IApplicationUserRepository
    {
        ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public void Update(ApplicationUser applicationUser)
        {
            _db.Update(applicationUser);
        }
    }
}
