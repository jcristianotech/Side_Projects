using JohnTestWebApp.Data;
using JohnTestWebApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JohnTestWebApp.Controllers
{
    public class HomeController : Controller
    {

        private static LeagueRepository leagueRepo = new LeagueRepository();


        public ActionResult Index()
        {
            List<TeamViewModel> teams = leagueRepo.GetAll();

            return View(teams);
        }

        public ActionResult Details(int? id)
        {
            TeamViewModel team = leagueRepo.GetById(id);
            if (team == null)
            {
                return RedirectToAction("Index");
            }
            return View(team);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamViewModel team, HttpPostedFileBase imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(team);

            }
            if (imageFile != null && imageFile.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath(@"~\Images\"),
                   team.TeamPictureFileName);
                    imageFile.SaveAs(path);
                }
                catch { }

            leagueRepo.Create(team);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            TeamViewModel team = leagueRepo.GetById(id.Value);

            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(TeamViewModel team, HttpPostedFileBase imageFile)
        {
            if (!ModelState.IsValid)
            {
                return View(team);

            }
            if (imageFile != null && imageFile.ContentLength > 0)
                try
                {
                    string path = Path.Combine(Server.MapPath(@"~\Images\"), 
                   team.TeamPictureFileName);
                    imageFile.SaveAs(path);
                }
                catch { }

            leagueRepo.Update(team);
            return RedirectToAction("Index");

        }

        public ActionResult Delete(int? id)
        {
            TeamViewModel team = leagueRepo.GetById(id);

            if (team == null)
            {
                return RedirectToAction("Index", "Home");
            }

            leagueRepo.Delete(id);
            return RedirectToAction("Index");
        }

      

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}