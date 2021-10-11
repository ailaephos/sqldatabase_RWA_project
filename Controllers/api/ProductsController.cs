using rwa_projekt_katlija_2407.App_Start;
using rwa_projekt_katlija_2407.Models;
using rwa_projekt_katlija_2407.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace rwa_projekt_katlija_2407.Controllers.api
{
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetProduct()
        {
            var products = Repo.GetProducts();
            var productdto = AutoMapperConfig.Mapper.Map<IEnumerable<Productdto>>(products);
            return Ok(productdto);
        }
        [HttpGet]
        public IHttpActionResult GetProduct(int id)
        {
            var product = Repo.GetProduct(id);
            if (product == null) return NotFound();
            var productdto = AutoMapperConfig.Mapper.Map<Productdto>(product);
            return Ok(productdto);
        }
        [HttpPost]
        public IHttpActionResult CreateProduct(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            Repo.CreateProduct(product);
            var productdto = AutoMapperConfig.Mapper.Map<Productdto>(product);
            return Ok(productdto);
        }
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            var pdb = Repo.GetProduct(id);
            if (pdb == null) return NotFound();
            Repo.UpdateProduct(product);
            var productdto = AutoMapperConfig.Mapper.Map<Productdto>(product);
            return Ok(productdto);
        }
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            var pdb = Repo.GetProduct(id);
            if (pdb == null) return NotFound();
            Repo.DeleteProduct(id);
            return Ok("Success");
        }
    }
}

