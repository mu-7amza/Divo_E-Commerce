using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CustomerBasket
    {
        public CustomerBasket(string id)
        {
            Id = id;
        }   
        public CustomerBasket()
        {

        }

        public string Id { get; set; }

        public List<BasketItem> Items { get; set; } = new List<BasketItem>();
    }

    
}