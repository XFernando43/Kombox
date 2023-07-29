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
    public class ShoppingCartRepository: Repository<ShoppingCart>,IShoppingCartRepository
    {
        ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db): base(db) 
        {
            _db = db;
        }
        public void Update(ShoppingCart shoppingCart)
        {
            _db.Update(shoppingCart);
        }
    }
}
