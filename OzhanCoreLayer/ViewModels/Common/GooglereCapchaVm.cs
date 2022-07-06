using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanCoreLayer.ViewModels.Common
{
    public class GooglereCapchaVm
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Capcha { get; set; }
    }
}
