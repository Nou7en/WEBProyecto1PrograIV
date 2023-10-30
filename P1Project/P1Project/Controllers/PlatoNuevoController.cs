using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P1Project.Service;

namespace P1Project.Controllers
{
    public class PlatoNuevoController : Controller
    {

        private readonly IAPIService _apiService;

        public PlatoNuevoController(IAPIService aPIService)
        {

            _apiService = aPIService;
        }
        // GET: PlatoNuevoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PlatoNuevoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlatoNuevoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlatoNuevoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatoNuevoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlatoNuevoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PlatoNuevoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlatoNuevoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
