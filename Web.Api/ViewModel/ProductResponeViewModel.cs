using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.ViewModel
{
    public class ProductResponeViewModel
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public ICollection<string> ImagesProduct { get; set; }
    }
}
