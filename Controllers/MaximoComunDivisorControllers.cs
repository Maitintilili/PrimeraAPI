using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PrimeraWebApi.Controllers
{
    public class MaximoComunDivisorControllers : Controller
    {
        // GET: MaximoComunDivisorControllers
        public ActionResult Index()
        {
            return View();
        }

        // GET: MaximoComunDivisorControllers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MaximoComunDivisorControllers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaximoComunDivisorControllers/Create
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

        // GET: MaximoComunDivisorControllers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MaximoComunDivisorControllers/Edit/5
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

        // GET: MaximoComunDivisorControllers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MaximoComunDivisorControllers/Delete/5
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
