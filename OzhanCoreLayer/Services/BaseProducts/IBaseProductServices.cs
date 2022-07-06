using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using OzhanCoreLayer.ViewModels.BaseProducts;
using OzhanDomainLayer.Entities.Products.Common;
using OzhanDomainLayer.Entities.Products.Crouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Services.BaseProducts
{
    public interface IBaseProductServices : GeneralServices.IGeneralServices<long, ProductIndexViewModle, ProductCreatOrEditViewModel>
    {
        Task<BaseProductVmForShow> ShowForAdminPage(string FilterByTitle = "", int page = 1);
        List<SelectListItem> GetAllLeaderGroupes();
        List<SelectListItem> GetAllSubGroupes(int groupId);
        Task<ProductCreatOrEditViewModel> Addproduct(ProductCreatOrEditViewModel vm1);
        Task<ProductCreatOrEditViewModel> GetProductByID(long id);
        Task<List<ShowProductInIndexViewModel>> GetProductForShowInIndex(int pageId=1,int Status = 1, string Filter="",List<int> selectedGroup=null,
            string orderbyPrice ="",double Stratprice=0,double endPrice=0 , int take=0);
        Task<ProductCreatOrEditViewModel> GetProductForSingleShow(long id);
    }
}
