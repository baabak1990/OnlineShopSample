using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using OzhanCoreLayer.Services.Products;
using OzhanCoreLayer.ViewModels.ProductVM;

namespace OzhanITFinalVersion.ViewComponents.MainMenu
{
    public class CourseGroupComponent:ViewComponent
    {
        private readonly IProductServices _services;

        public CourseGroupComponent(IProductServices services)
        {
            _services = services;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Todo : take care of naming view
            return await Task.FromResult((IViewComponentResult) View("~/Views/Shared/Components/CourseGroupComponent/CourseGroupe.cshtml",  await _services.GetAll()));
        }
    }
}
