using DagelijkseInname.Model;
using System.Collections.Generic;

namespace DagelijkseInname.Repository
{
    public interface IProductRepository
    {
        List<Product> HaalAlleProductenOp();
        Product HaalProductOp(int productId);
        void Nieuw(Product product);
        void Wijzig(Product product);
    }
}
