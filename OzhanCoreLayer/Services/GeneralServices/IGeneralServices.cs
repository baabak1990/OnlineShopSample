using System.Collections.Generic;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Services.GeneralServices
{
    public interface IGeneralServices<TKey, TGeneralIndexVm, TGeneralCreateOrEditVm>
    where TKey : struct
    where TGeneralIndexVm : IIndexVm<TKey>
    where TGeneralCreateOrEditVm : ICreateOrEditVM<TKey>
    {
        Task<TGeneralCreateOrEditVm> Find(TKey id);
        Task<TGeneralCreateOrEditVm> Add(TGeneralCreateOrEditVm vm);
        Task<TGeneralCreateOrEditVm> Edit(TGeneralCreateOrEditVm vm);
        Task<bool> Delete(TKey id);
        Task<List<TGeneralIndexVm>> GetAll();
        Task<bool> IsExist(int id);
    }
}