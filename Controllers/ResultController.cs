using System;
using System.IO;
using System.Linq;
using GoodResult.Data;
using GoodResult.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoodResult.Controllers
{
    [Authorize]
    public class ResultController : Controller
    {
        private readonly ApplicationDbContext context;
        public ResultController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {

            return View(null);
        }
        [HttpGet]
        public IActionResult Detail(int id)
        {
            var detail = context.Results.FirstOrDefault(x => x.Id == id);
            return View(detail);
        }
        [HttpGet]
        public IActionResult New()
        {
            ViewBag.AddMode = "yes";
            return View(new Result());
        }
        [AllowAnonymous]
        public IActionResult Search(string symbolNumber)
        {
            var result = context.Results.FirstOrDefault(x => x.SymbolNumber == symbolNumber);
            return View("Index", result);
        }
        [HttpPost]
        public IActionResult New(Result r, string AddMode, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                var fileUrl = UploadFile(file);
                r.ImageUrl = fileUrl;
                if (AddMode.Equals("yes"))
                {
                    context.Results.Add(r);
                    context.SaveChanges();
                }
                else
                {
                    context.Results.Update(r);
                    context.SaveChanges();
                }
            }
            else
            {
                return View();
            }
            return RedirectToAction("DisplayAllResult");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.AddMode = "no";
            var edit = context.Results.FirstOrDefault(x => x.Id == id);
            return View("New", edit);
        }
        [HttpPost]
        public IActionResult Update(Result r)
        {
            context.Results.Update(r);
            context.SaveChanges();
            return RedirectToAction("DisplayAllResult");
        }
        [HttpGet]
        public IActionResult DisplayAllResult()
        {
            var results = context.Results.ToList();
            return View(results);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var delete = context.Results.FirstOrDefault(x => x.Id == id);
            context.Results.Remove(delete);
            context.SaveChanges();
            return RedirectToAction("DisplayAllResult");
        }
         public IActionResult UpdateImage(int id, IFormFile file)
        {
            var employee = context.Results.FirstOrDefault(x => x.Id == id);
            var filePath = UploadFile(file);
            employee.ImageUrl = filePath;
            context.Results.Update(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
          public string UploadFile(IFormFile file)
        {
            var fileName = Guid.NewGuid().ToString() + file.FileName;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return fileName;
        }

    }
}