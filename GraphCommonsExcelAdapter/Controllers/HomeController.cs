using GraphCommonsExcelBusiness;
using GraphCommonsExcelBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace GraphCommonsExcelAdapter.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GenerateMap(List<Edge> edges, string excelFileName)
        {
            var filePath = Server.MapPath("files/" + excelFileName);
            var dataTable = ExcelUtility.LoadExcelIntoDataTable(filePath);
            var signalBuilder = new SignalBuilder();
            var graph = signalBuilder.BuildGraph(dataTable,edges);
            var client = new GraphCommonsClient();
            var response = client.PostGraph(graph);

            return Json(response);
        }

        public ViewResult GenerateMap(ExcelMetaData stats)
        {
            var model = TempData["metaData"] as ExcelMetaData;
            if (model == null)
                return View("Index");
            return View(model);
        }

        [HttpPost]
        public RedirectToRouteResult UploadExcel(HttpPostedFileBase file)
        {
            using (var fileStream = file.InputStream)
            {
                var metaData = ExcelUtility.GetExcelMetaData(fileStream);
                metaData.FileName = Path.GetFileName(file.FileName);

                file.SaveAs(Server.MapPath("files/" + metaData.FileName));
                TempData["metaData"] = metaData;

                return RedirectToAction("GenerateMap");
            }
        }
    }
}