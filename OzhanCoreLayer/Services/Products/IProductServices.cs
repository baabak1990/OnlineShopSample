using OzhanCoreLayer.Services.GeneralServices;
using OzhanCoreLayer.ViewModels.ProductVM;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Services.Products
{
    public interface IProductServices : IGeneralServices<int, ProductGroupeIndex, ProductGroupeCreateOrEdit>
    {
        Task<ProductGroupeIndex> ShowLeaderGroups();
        Task<ProductGroupeCreateOrEdit> GetGroupById(int Id);
    }
}