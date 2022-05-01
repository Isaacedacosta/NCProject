using Microsoft.AspNetCore.Mvc;
using NCProjectApplication.Services;

namespace NCProject.Controllers
{
    public class LocationsController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Locations = WebServices.AllAttractions();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public void CreateLocation()
        {
            string nome = Request.Form["Nome"];
            string descricao = Request.Form["Descricao"];
            string localizacao = Request.Form["Localizacao"];
            string cidade = Request.Form["Cidade"];
            string estado = Request.Form["Estado"];

            if(WebServices.AddAttraction(nome, descricao, localizacao, cidade, estado))
            {
                Redirect("/Locations");
            }
            else
            {
                BadRequest();
            }
        }

    }
}
