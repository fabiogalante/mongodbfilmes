
using LocadoraDevmedia.Models;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LocadoraDevmedia.Controllers
{
    public class FilmesMVCController : Controller
    {
        private readonly FilmesController _apiController;

        public FilmesMVCController()
        {
            _apiController = new FilmesController();
        }
        

        // GET: Filmes
        public async Task<ActionResult> Index()
        {
            var lista = await _apiController.Get();
            return View(lista);
        }

        // GET: Filmes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Filmes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Filmes/Create
        [HttpPost]
        public async Task<ActionResult> Create(Filme filme)
        {
            try
            {
                 _apiController.Post(filme);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filmes/Edit/5
        public ActionResult Edit(string _id)
        {
            var dados = _apiController.Get(_id);
            ViewBag.MongoId = dados._id;

            return View(dados);
        }

        // POST: Filmes/Edit/5
        [HttpPost]
        public ActionResult Edit(string _id, Filme filme)
        {
            //var MongoIdConv = new ObjectId(_id);
            filme._id = new ObjectId(_id);

            try
            {
                _apiController.Put(_id, filme);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Filmes/Delete/5
        public ActionResult Delete(string _id)
        {
            var dados = _apiController.Get(_id);
            ViewBag.MongoId = dados._id;

            return View(dados);
        }

        // POST: Filmes/Delete/5
        [HttpPost]
        public ActionResult Delete(string _id, Filme f)
        {
            var dados = _apiController.Get(_id);
            var MongoIdConv = dados._id;

            try
            {
                _apiController.Delete(new ObjectId(_id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
