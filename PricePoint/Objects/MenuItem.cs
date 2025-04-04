using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PricePoint.Objects
{
    [Table("MenuItems")]
    public class MenuItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Column("restaurantid")]
        public int RestaurantId { get; set; }
        [Column("itemtype")]
        public string ItemType { get; set; }
        [Column("price")]
        public double Price { get; set; }
        [Column("itemname")]
        public string ItemName { get; set; }
        [Column("itemdescription")]
        public string ItemDescription { get; set; }

    }
}
