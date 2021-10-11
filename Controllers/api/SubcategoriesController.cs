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
    public class SubcategoriesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetSubcategory()
        {
            var scategory = Repo.GetSubcategories();
            var scategorydto = AutoMapperConfig.Mapper.Map<IEnumerable<Subcategorydto>>(scategory);
            return Ok(scategorydto);
        }
        [HttpGet]
        public IHttpActionResult GetSubcategory(int id)
        {
            var scategory = Repo.GetSubcategory(id);
            if (scategory == null) return NotFound();
            var scategorydto = AutoMapperConfig.Mapper.Map<Subcategorydto>(scategory);
            return Ok(scategorydto);
        }
        [HttpPost]
        public IHttpActionResult CreateSubcategory(Subcategory subcategory)
        {
            if (!ModelState.IsValid) return BadRequest();
            Repo.CreateSubcategory(subcategory);
            var scategorydto = AutoMapperConfig.Mapper.Map<Subcategorydto>(subcategory);
            return Ok(scategorydto);
        }
        [HttpPut]
        public IHttpActionResult UpdateSubcategory(int id, Subcategory subcategory)
        {
            if (!ModelState.IsValid) return BadRequest();
            var sdb = Repo.GetSubcategory(id);
            if (sdb == null) return NotFound();
            Repo.UpdateSubcategory(subcategory);
            var scategorydto = AutoMapperConfig.Mapper.Map<Subcategorydto>(subcategory);
            return Ok(scategorydto);
        }
        [HttpDelete]
        public IHttpActionResult DeleteSubcategory(int id)
        {
            var cdb = Repo.GetSubcategory(id);
            if (cdb == null) return NotFound();
            Repo.DeleteSubcategory(id);
            return Ok("Success");
        }
    }
}
