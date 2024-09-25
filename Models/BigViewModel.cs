using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WorldKitchen.Models;

namespace WorldKitchen.Models
{
    public class BigViewModel
    {
        public IEnumerable<DatabaseWorldKitchenCountry>? CountryTable { get; set; }
        public IEnumerable<DatabaseWorldKitchenDishies>? DishiesTable { get; set; }
    }
}

