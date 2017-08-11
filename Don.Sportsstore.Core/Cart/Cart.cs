using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Values;
using Don.Sportsstore.Products;

namespace Don.Sportsstore.Carts
{
    public class Cart : ValueObject<Cart>
    {
        private readonly List<CartLine> _lineCollection = new List<CartLine>();
 

        public void AddItem(Product product, int quantity)
        {
            CartLine line = _lineCollection.FirstOrDefault(c => c.Product.Id == product.Id);

            if (line == null)
            {
                _lineCollection.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            _lineCollection.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal CalcTotalValue()
        {
            return _lineCollection.Sum(c => c.Product.Price * c.Quantity);
        }

        public void Clear()
        {
            _lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return _lineCollection; }
            
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}