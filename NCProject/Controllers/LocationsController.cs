using Microsoft.AspNetCore.Mvc;
using NCProjectApplication.Services;

namespace NCProject.Controllers
{
    public class LocationsController : Controller
    {
        #region Read
        [HttpGet]
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
        public IActionResult Sort(int? Id)
        {
            var Table = WebServices.AllAttractions();
            int numberOfPages = WebServices.NumberOfPages(Table);
            int _id;
            if (Id == null)
            {
                _id = 0;
            }
            else
            {
                _id = Id.Value;

            }
            bool reachable = (numberOfPages >= _id);
            if (reachable == false)
            {
                return NotFound();
            }
            ViewBag.Filtro = WebServices.GetAllPaginated(_id);
            ViewBag.Estados = WebServices.EstadosDisponiveis;
            ViewBag.NumeroPaginas = numberOfPages;
            ViewBag.PaginaAtual = Id;
            return View();
        } 
        #endregion

        [HttpGet]
        public IActionResult Search(string Id)
        {
            string[] queryParser = WebServices.queryParser(Id);
            string searchQuery = queryParser[0];
            int.TryParse(queryParser[1], out int indexBusca);
            var tableResultsAll = WebServices.GetBySearch(searchQuery);
            var tableResultsDisplay = WebServices.Filter(tableResultsAll, indexBusca);
            int totalDePaginas = WebServices.NumberOfPages(tableResultsAll);
            string[] CarrosselButons = WebServices.CarrosselButons(indexBusca, totalDePaginas, searchQuery);
            ViewBag.Filtro = tableResultsDisplay;
            ViewBag.NumeroPaginas = totalDePaginas;
            ViewBag.PaginaAtual = indexBusca;
            ViewBag.PaginaAnterior = CarrosselButons[0];
            ViewBag.ProximaPagina = CarrosselButons[1];
            ViewBag.QuerySearched = searchQuery;
            ViewBag.Estados = WebServices.EstadosDisponiveis;
            return View();
        }

        [HttpPost]
        public IActionResult SearchLocations()
        {
            string searchQuery = Request.Form["inputSearch"];
            string indexSelected = Request.Form["indexPageHolder"];            

            return Redirect($"/Locations/Search/{searchQuery}-atIndex{indexSelected}");
        }

        [HttpPost]
        public IActionResult SearchLocationsWithIndex(int pageNumber)
        {
            int testestesss = pageNumber;
            string searchQuery = Request.Form["inputSearch"];
            string indexBuscaString = Request.Form["indexSelected"];
            string indexPaginaSelected = Request.Form["indexPageHolder"];
            int.TryParse(indexPaginaSelected, out int indexBusca);
            
            

            return Redirect($"/Locations/Search/{searchQuery}");
        }


        

        #region Update
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
                return Redirect("/Locations/Sort/1");
            }
            else
            {
                return NotFound();
            }
        } 
        #endregion

        #region Create
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
                return Redirect("/Locations/Sort/1");
            }
            else
            {
                return NotFound();
            }
        } 
        #endregion

        #region Delete
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
                return Redirect("/Locations/Sort/1");
            }
            else
            {
                return NotFound();
            }
        } 
        #endregion
    }
}
