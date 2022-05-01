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
        public IActionResult Read(int Id)
        {
            ViewBag.Location = WebServices.AttractionById(Id);
            ViewBag.Estados = WebServices.EstadosDisponiveis;
            return View();
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            ViewBag.Location = WebServices.AttractionById(Id);
            ViewBag.Estados = WebServices.EstadosDisponiveis;
            return View();
        }
        [HttpPost]
        public IActionResult UpdateLocation(int Id)
        {
            string nome = Request.Form["Nome"];
            string descricao = Request.Form["Descricao"];
            string localizacao = Request.Form["Localizacao"];
            string cidade = Request.Form["Cidade"];
            string estado = Request.Form["Estado"];


            if (WebServices.UpdateAttraction(Id, nome, descricao, localizacao, cidade, estado) == true)
            {
                return Redirect("/Locations");
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Estados = WebServices.EstadosDisponiveis;
            return View();
        }
        [HttpPost]
        public IActionResult CreateLocation()
        {
            string nome = Request.Form["Nome"];
            string descricao = Request.Form["Descricao"];
            string localizacao = Request.Form["Localizacao"];
            string cidade = Request.Form["Cidade"];
            string estado = Request.Form["Estado"];


            if (WebServices.AddAttraction(nome, descricao, localizacao, cidade, estado) == true)
            {
                return Redirect("/Locations");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            ViewBag.Location = WebServices.AttractionById(Id);
            ViewBag.Estados = WebServices.EstadosDisponiveis;
            return View();
        }
        [HttpPost]
        public IActionResult DeleteLocation(int Id)
        {
            if (WebServices.DeleteAttraction(Id) == true)
            {
                return Redirect("/Locations");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
