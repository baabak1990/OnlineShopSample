using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.Services.GeneralServices
{
    public class IIndexVm<Tkey>where Tkey:struct
    {
        public Tkey Id { get; set; }
    }
}
