using System;
using System.Collections.Generic;

#nullable disable

namespace Web.Api.Models
{
    public partial class Product
    {
        public Product()
        {
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public int CatId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public bool? SoftDelete { get; set; }

        public virtual Category Cat { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}
