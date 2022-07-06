using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using OzhanCoreLayer.ViewModels.Common;

namespace OzhanCoreLayer.Services.GeneralServices
{
    public class ICreateOrEditVM<TKey>
    where TKey : struct
    {
        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
