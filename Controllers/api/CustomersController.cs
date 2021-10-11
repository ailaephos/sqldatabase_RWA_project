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
    public class CustomersController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetCustomers()
        {
            var customers = Repo.GetAllCustomers();
            var customerdto = AutoMapperConfig.Mapper.Map<IEnumerable<Customerdto>>(customers);
          
            return Ok(customerdto);
        }
        [HttpGet]
        public IHttpActionResult GetCustomer(int id)
        {
            var customers = Repo.ShowMoreInfo(id);
            if (customers == null) return NotFound();
            var customerdto = AutoMapperConfig.Mapper.Map<Customerdto>(customers);
            return Ok(customerdto);
        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            Repo.CreateCustomer(customer);
            var customerdto = AutoMapperConfig.Mapper.Map<Customerdto>(customer);
            return Ok(customerdto);
        }
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid) return BadRequest();
            var cdb = Repo.ShowMoreInfo(id);
            if (cdb == null) return NotFound();
            Repo.UpdateCustomer(customer);
            var customerdto = AutoMapperConfig.Mapper.Map<Customerdto>(customer);
            return Ok(customerdto);
        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var cdb = Repo.ShowMoreInfo(id);
            if (cdb == null) return NotFound();
            Repo.DeleteCustomer(id);        
            return Ok("Success");
        }
    }
}
