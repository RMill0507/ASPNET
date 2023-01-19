using Microsoft.AspNetCore.Mvc;
using Testing.Models;

namespace Testing.Controllers
{
    public class ProductController : Controller//conforming to product controller
    {
        private readonly IProductRepository repo;//creating an obj

        public ProductController(IProductRepository repo)//our constructor passing in a repo of IPRODUCTREPOSITORY
        {
            this.repo = repo;//connecting
        }


        public IActionResult Index()
        {
            var products = repo.GetAllProducts();//calling our repo to get GetAllPRoducts methods
            return View(products);//passing in ienumerable collection of products
        }
        public IActionResult ViewProduct(int id)
        {
            var product = repo.GetProduct(id);//returning a single product
            //the view is going to take the data
            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod = repo.GetProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }
        public IActionResult UpdateProductoDatabase(Product product)
        {
            repo.UpdateProduct(product);

            return RedirectToAction("ViewProduct", new { id = product.ProductID });
        }
        public IActionResult InsertProduct()
        {
            var prod = repo.AssignCategory();
            return View(prod);
        }
        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteProduct(Product product)
        {
            repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }
    }
}
