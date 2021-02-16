using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LidiaDishnica;
using LidiaDishnicaWeb.Models;

namespace LidiaDishnicaWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //take all the parents
            CommodityChapters cch = new CommodityChapters();
            var parents = cch.Search();
            List<CommodityChapterModel> model = new List<CommodityChapterModel>();
            foreach (var item in parents)
            {
              
                CommodityChapterModel cm = new CommodityChapterModel();
                cm.Code = item.Code;
                cm.Name = item.Name;
                CommodityRoots commodityRoots = new CommodityRoots();
                //take the children
                var elements = commodityRoots.GetByIdParent(item.Id);
                cm.CommodityRootsItems = elements;
                model.Add(cm);
            }

            return View("Index", model);
        }
        public ActionResult Edit(int Id)
        {
            CommodityRoots frnds = new CommodityRoots();
            CommodityRootsModel rootsModel = new CommodityRootsModel();
            var element = frnds.GetById(Id);
            rootsModel.Active = element.Active;
            rootsModel.Code = element.Code;
            rootsModel.CommodityChapterId = element.CommodityChapterId;
            rootsModel.Description = element.Description;
            rootsModel.Name = element.Name;
            rootsModel.id = element.Id;

            return PartialView("_PopUpTree", rootsModel);
        }

        [HttpPost]
        public ActionResult Save(CommodityRootsModel commodityRootsModel)
        {
            CommodityRoots com = new CommodityRoots();
            com= com.GetById(commodityRootsModel.id);
            commodityRootsModel.Fill(com);
            com.Save();
         return   RedirectToAction("Index");
         

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