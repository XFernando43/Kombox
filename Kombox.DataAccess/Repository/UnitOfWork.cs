using Kombox.DataAccess.Data;
using Kombox.DataAccess.Repository.IRepository;

namespace Kombox.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _db;

        public ICategoryRepository CategoryRepository { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public ICompanyRepository CompanyRepository { get; set; }
        public IShoppingCartRepository ShoppingCartRepository { get; set; }
        public IApplicationUserRepository UserRepository { get; set; }
     
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            ProductRepository = new ProductRepository(_db);
            CompanyRepository = new CompanyRepository(_db);
            ShoppingCartRepository  = new ShoppingCartRepository(_db);
            UserRepository = new ApplicationUserRepository(_db);
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
