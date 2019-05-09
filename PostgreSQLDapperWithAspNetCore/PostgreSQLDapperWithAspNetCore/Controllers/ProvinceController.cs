using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PostgreSQLDapperWithAspNetCore.Models;
using PostgreSQLDapperWithAspNetCore.Repository;

namespace PostgreSQLDapperWithAspNetCore.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly ProvinceRepository provinceRepository;

        public ProvinceController(IConfiguration configuration)
        {
            provinceRepository = new ProvinceRepository(configuration);
        }

        public IActionResult Index()
        {
            return View(provinceRepository.FindAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public IActionResult Create(Province province)
        {
            if (ModelState.IsValid)
            {
                provinceRepository.Add(province);
                return RedirectToAction("Index");
            }
            return View(province);
        }

        // GET: /Customer/Edit/1
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Province obj = provinceRepository.FindByID(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: /Customer/Edit
        [HttpPost]
        public IActionResult Edit(Province obj)
        {
            if (ModelState.IsValid)
            {
                provinceRepository.Update(obj);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET:/Customer/Delete/1
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            provinceRepository.Remove(id.Value);
            return RedirectToAction("Index");
        }
    }
}