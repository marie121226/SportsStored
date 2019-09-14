using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {

        public int PageSize = 5;
        // GET: Product
        //****Property injection
        public IProductsRepository ProductsRepository { get; set; }
        //public IEnumerable<Product> List(int page)
        //{
        //    return ProductsRepository.Products;
        //}
        public ViewResult List(string Category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = ProductsRepository
                .Products
                .Where(p => Category == null || p.Category == Category)
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository
                .Products.Where(p => Category == null || p.Category == Category).Count()
                },
                CurrentCategory = Category

            };
            return View(model);
            //return View(ProductsRepository.Products);
            //return
            //    View(
            //ProductsRepository
            //.Products
            //.OrderBy(p => p.ProductId)
            //.Skip((page - 1) * PageSize)
            //.Take(PageSize));

        }
        //think about sorting
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