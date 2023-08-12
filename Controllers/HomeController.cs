using main6project.Models;
using main6project.Models.ViewModels;
using main6project.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace main6project.Controllers
{
    public class HomeController : Controller
    {
        Main4projectContext db  = new Main4projectContext();
        public IActionResult List(Provinetable test)
        {
            
          
            var list = db.Maintables.ToList();
            return View(list);
        }

        public IActionResult Create()
        {
            var provincelist = db.Provinetables.ToList();
            Provinetable model = new Provinetable
            {
                ProvinceId = -1,
                ProvinceName = "select province"

            };
            provincelist.Insert(0, model);
            ViewBag.provinceli = provincelist;

            return View();
        }
         
        public IActionResult getcity(int id)
        {
            var citylist = db.Citytables.Where(c => c.ProvinceId == id)
                .Select(e => new { id = e.CityId, name = e.CityName }).ToList();

            return Json(new { status = "success", citylist });

        }
        [HttpPost]
        public  IActionResult Create( Creatvm viewmodelimage, Maintable testmain, IFormFile imageupload ,[FromServices] IWebHostEnvironment env) {
            Maintable user = new Maintable()
            {
                Name = viewmodelimage.Name,
                Family = viewmodelimage.Family,
                Password = viewmodelimage.Password,
                Province = viewmodelimage.Province,
                City = viewmodelimage.City,
           
                

             };
           
                if (imageupload != null && imageupload.Length > 0)
                {
                    if (imageupload.ContentType != "image/jpeg" && imageupload.ContentType != "image/png")
                    {
                        ModelState.AddModelError("imageupload", "yout image format must be jpeg or png");
                        return View(user);
                    }
                    if (imageupload.Length > 2 * 1024 * 1024)
                    {
                        ModelState.AddModelError("imageupload", "your image size must be less than 2MB");
                        return View(user);
                    }

                    string uniqfilename = Guid.NewGuid().ToString() + Path.GetExtension(imageupload.FileName);
                    string filepath = Path.Combine(env.WebRootPath, "Images", uniqfilename);

                    using (var stream = new FileStream(filepath, FileMode.Create))
                    {
                        imageupload.CopyToAsync(stream);
                    }
                    user.ImageName = uniqfilename;

                    db.Maintables.Add(user);
                    db.SaveChanges();
                    return RedirectToAction("List");
                }





            


            return View(testmain);

        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintable list = db.Maintables.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }

        // GET: /Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintable list = db.Maintables.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            }
            return View(list);
        }

        // POST: /Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maintable list = db.Maintables.Find(id);
            db.Maintables.Remove(list);
            db.SaveChanges();
            return RedirectToAction("List");
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maintable list  = db.Maintables.Find(id);
            if (list == null)
            {
                return HttpNotFound();
            };
            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include : "Name, Family ,Password , Province ,City,ImageName")] Maintable list)
        {
            if (ModelState.IsValid)
            {
                db.Entry(list).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(list);
        }
    }



}