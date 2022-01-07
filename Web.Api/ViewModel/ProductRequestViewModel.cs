using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Api.ViewModel
{
    public class ProductRequestViewModel
    {
        public string Name { get; set; }
        public int CatId { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<IFormFile> ImagesProduct { get; set; }
    }
}
