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
    public class CategoriesController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCategory()
        {
            var category = Repo.GetCategories();
            var categorydto = AutoMapperConfig.Mapper.Map<IEnumerable<Categorydto>>(category);
            return Ok(categorydto);
        }
        [HttpGet]
        public IHttpActionResult GetCategory(int id)
        {
            var category = Repo.GetCategory(id);
            if (category == null) return NotFound();
            var categorydto = AutoMapperConfig.Mapper.Map<Categorydto>(category);
            return Ok(categorydto);
        }
        [HttpPost]
        public IHttpActionResult CreateCategory(Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            Repo.CreateCategory(category);
            var categorydto = AutoMapperConfig.Mapper.Map<Categorydto>(category);
            return Ok(categorydto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCategory(int id, Category category)
        {
            if (!ModelState.IsValid) return BadRequest();
            var cdb = Repo.GetCategory(id);
            if (cdb == null) return NotFound();
            Repo.UpdateCategory(category);
            var categorydto = AutoMapperConfig.Mapper.Map<Categorydto>(category);
            return Ok(categorydto);
        }
        [HttpDelete]
        public IHttpActionResult DeleteCategory(int id)
        {
            var cdb = Repo.GetCategory(id);
            if (cdb == null) return NotFound();
            Repo.DeleteCategory(id);
            return Ok("Success");
        }
    }
}
