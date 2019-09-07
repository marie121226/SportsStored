using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        //****Property injection
        public IProductsRepository ProductsRepository { get; set; }
        public ViewResult List()
        {
            return View(ProductsRepository.Products);
        }
        //****
        //****construct injection
        //private IProductsRepository repository;

        //public ProductController(IProductsRepository productsRepository)
        //{
        //    this.repository = productsRepository;
        //}

        //public ViewResult List()
        //{
        //    return View(repository.Products);
        //}
        //****
    }
}