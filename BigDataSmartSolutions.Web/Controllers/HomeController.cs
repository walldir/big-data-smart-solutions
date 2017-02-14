using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace BigDataSmartSolutions.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public FileContentResult ConvertExcelToCsv()
        {
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                try
                {
                    if (file != null && Core.Util.Excel.IsValido(file))
                    {
                        var csv = Core.Util.Excel.ExcelToCsv(Server.MapPath("~/Content"), file);

                        return File(new System.Text.UTF8Encoding().GetBytes(csv), "text/csv",
                            $"{Path.GetFileNameWithoutExtension(file.FileName)}.csv");
                    }
                    else
                    {
                        throw new Exception("Erro ao carregar arquivo");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                throw new Exception("Nenhum arquivo selecionado");
            }
        }
    }
}