using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricePoint.Objects
{
    [Table("Restaurants")]
    public class Restaurant
    {
        [PrimaryKey, AutoIncrement]
        public int RestaurantId { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("pricepoint")]
        public int Pricepoint { get; set; }
        [Column("type")]
        public string Type { get; set; }
        [Column("location")]
        public string Location { get; set; }

    }
}
