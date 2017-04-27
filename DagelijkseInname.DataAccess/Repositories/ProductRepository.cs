using DagelijkseInname.Model;
using DagelijkseInname.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace DagelijkseInname.DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> HaalAlleProductenOp()
        {
            using (var context = new DagelijkseInnameContext())
            {
                return context.Producten
                              .OrderBy(p => p.Naam)
                              .ToList();
            }
        }

        public Product HaalProductOp(int productId)
        {
            using (var context = new DagelijkseInnameContext())
            {
                return context.Producten.Where(p => p.Id == productId).FirstOrDefault();
            }
        }

        public void Nieuw(Product product)
        {
            using (var context = new DagelijkseInnameContext())
            {
                context.Producten.Add(product);
                context.SaveChanges();
            }
        }

        public void Wijzig(Product product)
        {
            using (var context = new DagelijkseInnameContext())
            {
                context.Producten.Attach(product);
                context.Entry(product).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
