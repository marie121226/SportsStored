using System.Linq;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.WebApp.Models;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {

        public int PageSize = 2;
        // GET: Product
        //****Property injection
        public IProductsRepository ProductsRepository { get; set; }

        public ViewResult List(int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products = ProductsRepository
                .Products
                .OrderBy(p => p.ProductId)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = ProductsRepository
                .Products.Count()
                }

            };
            return View(model);
            //return View(ProductsRepository.Products);
            //return
            //    View(
            //model
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