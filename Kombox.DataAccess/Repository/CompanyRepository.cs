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
    public class CompanyRepository: Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db { get; set; }
        public CompanyRepository(ApplicationDbContext db): base(db) {
            _db = db;
        }   
        public void Update(Company company)
        {
            _db.companies.Update(company);
        }
    }
}
