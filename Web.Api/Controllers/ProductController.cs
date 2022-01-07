using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Web.Api.Models;
using Web.Api.ViewModel;

namespace Web.Api.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        const string Folder_Redirect = "Resources/Products/Images/";
        private readonly QLBHContext _dbContext;

        public ProductController(QLBHContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Get all product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ProductResponeViewModel> Get()
        {
            return _dbContext.Products
                        .Include(c => c.Cat)
                        .Include(i => i.Images)
                        .Where(p => !p.SoftDelete.Value)
                        .Select(p => new ProductResponeViewModel
                        {
                            Name = p.Name,
                            Category = p.Cat.Name,
                            Description = p.Description,
                            Price = p.Price.Value,
                            ImagesProduct = p.Images.Select(x => Folder_Redirect + x.Path).ToList()
                        });
        }

        /// <summary>
        /// Get product by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public ProductResponeViewModel GetById(int id)
        {
            return _dbContext.Products
                       .Include(c => c.Cat)
                       .Include(i => i.Images)
                       .Where(p => p.Id == id)
                       .Select(p => new ProductResponeViewModel
                       {
                           Name = p.Name,
                           Category = p.Cat.Name,
                           Description = p.Description,
                           Price = p.Price.Value,
                           ImagesProduct = p.Images.Select(x => Folder_Redirect + x.Path).ToList()
                       }).FirstOrDefault();
        }

        /// <summary>
        /// Add product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public bool Post([FromBody] ProductRequestViewModel request)
        {
            var product = new Product
            {
                Name = request.Name,
                CatId = request.CatId,
                Price = request.Price,
                Description = request.Description
            };
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            foreach (var item in request.ImagesProduct)
            {
                var nameFile = UploadedFile(item);
                var image = new Image
                {
                    IdProduct = product.Id,
                    Path = nameFile
                };
                _dbContext.Images.Add(image);
                _dbContext.SaveChanges();
            };
            return true;
        }

        /// <summary>
        /// Update product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{pId}")]
        public bool Put(int pId, [FromBody] ProductRequestViewModel request)
        {
            if (pId != 0)
            {
                var product = _dbContext.Products.FirstOrDefault(x => x.Id.Equals(pId));

                product.CatId = request.CatId;
                product.Name = request.Name;
                product.Description = request.Description;
                product.Price = request.Price;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        [HttpDelete]
        [Route("{pId}")]
        public bool Delete(int pId)
        {
            if(pId != 0)
            {
                var product = _dbContext.Products.FirstOrDefault(x => x.Id.Equals(pId) && !x.SoftDelete.Value);

                if (product == null)
                {
                    return false;
                }
                product.SoftDelete = true;
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }
        private string UploadedFile(IFormFile model)
        {
            string uniqueFileName = null;

            if (model != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Resources", "Products", "Images");
                var extensionName = Path.GetExtension(model.FileName);
                uniqueFileName = Guid.NewGuid().ToString() + extensionName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        private bool DeleteFile(List<IFormFile> files)
        {
            return true;
        }
    }
}
