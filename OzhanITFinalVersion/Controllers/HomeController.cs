using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzhanCoreLayer.Services.BaseProducts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OzhanITFinalVersion.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBaseProductServices _Service;

        public HomeController(IBaseProductServices service)
        {
            _Service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _Service.GetProductForShowInIndex());
        }


        public IActionResult GetSubGroupFromGroup(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text ="انتخاب کنید",Value=""}
            };
            list.AddRange(_Service.GetAllSubGroupes(id));
            return Json(new SelectList(list,"Value","Text"));
        }


        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();



            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/MyImages",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }



            var url = $"{"/MyImages/"}{fileName}";


            return Json(new { uploaded = true, url });
        }

        [HttpGet("Products")]
        public async Task<IActionResult> ShowProduct(int pageId = 1, int Status = 1, string Filter = "", List<int> selectedGroup = null,
            string orderbyPrice = "", double Stratprice = 0, double endPrice = 0, int take = 0)
        {
            return View( await _Service.GetProductForShowInIndex(pageId, Status, Filter, selectedGroup, orderbyPrice, Stratprice, endPrice, take));
        }

        [Route("ShowSingleProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> ShowSingleProducts(long id)
        {
            return View(await _Service.GetProductForSingleShow(id));
        }
    }
}
