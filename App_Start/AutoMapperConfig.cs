using AutoMapper;
using rwa_projekt_katlija_2407.Models;
using rwa_projekt_katlija_2407.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace rwa_projekt_katlija_2407.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Customer, Customerdto>();
                cfg.CreateMap<Product, Productdto>();
                cfg.CreateMap<Category, Categorydto>();
                cfg.CreateMap<Subcategory, Subcategorydto>();
            });       
              
            Mapper = config.CreateMapper();
        }
    }
}