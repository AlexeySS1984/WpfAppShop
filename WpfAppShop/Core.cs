using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppShop
{
    public static class Core
    {
        public static OnlineStoreDBEntities Context = new OnlineStoreDBEntities();

        public static List<Products> MyCart = new List<Products>();
    }
}
