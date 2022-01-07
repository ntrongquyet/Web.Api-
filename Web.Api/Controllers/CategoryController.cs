using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Api.Models;
using Web.Api.ViewModel;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly QLBHContext _dbContext;

        public CategoryController(QLBHContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<CategoryResponeViewModel> Get()
        {
            return _dbContext.Categories.Select(
                p => new CategoryResponeViewModel
                {
                    Id = p.Id,
                    Name = p.Name
                });
        }
    }


}
