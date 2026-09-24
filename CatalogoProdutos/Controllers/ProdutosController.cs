using Microsoft.AspNetCore.Mvc;

namespace CatalogoProdutos.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}