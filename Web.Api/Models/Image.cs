using System;
using System.Collections.Generic;

#nullable disable

namespace Web.Api.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public int? IdProduct { get; set; }
        public string Path { get; set; }

        public virtual Product IdProductNavigation { get; set; }
    }
}
