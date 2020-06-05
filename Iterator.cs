using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LV6
{
     interface IAbstractIterator    
     {     
         Product First();   
         Product Next();     
         bool IsDone { get; } 
         Product Current { get; }    
     } 

    class Iterator
    {
        private Box box;
        private int currentPositione;

        public Iterator(Box box)
        {
            this.box = box;
            this.currentPositione = 0;
        }

        public bool IsDone { get { return this.currentPositione >= this.box.Count; } }
        public Product Current { get { return this.box[this.currentPositione]; } }
        public Product First() { return this.box[0]; }
        public Product Next()
        {
            this.currentPositione++;
            if (this.IsDone)
            {
                return null;
            }
            else
            {
                return this.box[this.currentPositione];
            }
        }
    }

    class Product
    {
        public string Description { get; private set; }   
        public double Price { get; private set; }

        public Product(string description, double price)
        {
            this.Description = description;
            this.Price = price;
        }

        public override string ToString() 
        {
            return this.Description + ":\n" + this.Price;
        }
    }

    class Box
    {
        private List<Product> products;

        public Box() 
        { 
            this.products = new List<Product>(); 
        }     
        public Box(List<Product> products)
        { 
            this.products = new List<Product>(products.ToArray()); 
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }      
        public void RemoveProduct(Product product) 
        { 
            this.products.Remove(product);
        }     
        public int Count { get { return this.products.Count; } }
    } 
}
