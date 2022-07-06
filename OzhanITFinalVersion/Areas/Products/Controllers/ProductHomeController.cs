using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzhanCoreLayer.Services.BaseProducts;
using OzhanCoreLayer.Services.Products;
using OzhanCoreLayer.ViewModels.BaseProducts;
using OzhanCoreLayer.ViewModels.ProductVM;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace OzhanITFinalVersion.Areas.Products.Controllers
{
    public class ProductHomeController : ProductBaseController
    {


        private readonly IProductServices _services;
        private readonly IBaseProductServices _BaseServices;

        public ProductHomeController(IProductServices services, IBaseProductServices baseServices)
        {
            _services = services;
            _BaseServices = baseServices;
        }
        #region ProductGroup
        public async Task<IActionResult> ShowLeaderBoards()
        {
            return View(await _services.ShowLeaderGroups());
        }

        [HttpGet("AddCourse")]
        public async Task<IActionResult> AddLeaderCourse()
        {
            return View();
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> AddLeaderCourse(ProductGroupeCreateOrEdit vm)
        {
            await _services.Add(vm);
            return RedirectToAction("ShowLeaderBoards", "ProductHome", new { area = "Products" });
        }

        [HttpGet("EditGorup/{Id}")]
        public async Task<IActionResult> EditLeaderBoard(int Id)
        {
            return View(await _services.GetGroupById(Id));
        }

        [HttpPost("EditGorup/{Id}")]
        public async Task<IActionResult> EditLeaderBoard(ProductGroupeCreateOrEdit vm)
        {
            await _services.Edit(vm);
            return RedirectToAction("ShowLeaderBoards", "ProductHome", new { area = "Products" });
        }
        #endregion

        #region Products
        [HttpGet("ShowAllProducts")]
        public async Task<IActionResult> ShowAllProducts(string FilterByTitle = "", int page = 1)
        {
            return View(await _BaseServices.ShowForAdminPage(FilterByTitle, page));
        }

        //ToDo : add http post of show

        [HttpGet("AddProduct")]
        public async Task<IActionResult> AddProduct()
        {
            var gorup = _BaseServices.GetAllLeaderGroupes();
            ViewData["Group"] = new SelectList(gorup, "Value", "Text");
            //havaset baseh be in mored ke parantez chetor por shode
            var Subgorup = _BaseServices.GetAllSubGroupes(int.Parse(gorup.First().Value));
            ViewData["SubGroup"] = new SelectList(Subgorup, "Value", "Text");
            return View();
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductCreatOrEditViewModel vm)
        {
            if (ModelState.IsValid)
                return View(vm);
            await _BaseServices.Addproduct(vm);
            return RedirectToAction("ShowAllProducts", "ProductHome", new { area = "Products" });
        }

        [HttpGet("AddProduct/{id}")]
        public async Task<IActionResult> EditProduct(long id)
        {
            var show = await _BaseServices.GetProductByID(id);
            //TODO Ask How To fill secend List
            var gorup = _BaseServices.GetAllLeaderGroupes();
            ViewData["Group"] = new SelectList(gorup, "Value", "Text",show.CourseGroup);
            //havaset baseh be in mored ke parantez chetor por shode
            var Subgorup = _BaseServices.GetAllSubGroupes(int.Parse(gorup.First().Value));
            ViewData["SubGroup"] = new SelectList(Subgorup, "Value", "Text",int.Parse(Subgorup.First().Value));
            return View(show);
        }
        #endregion
    }
}
