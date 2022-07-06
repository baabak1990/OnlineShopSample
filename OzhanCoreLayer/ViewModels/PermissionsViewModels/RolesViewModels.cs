using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanCoreLayer.Services.GeneralServices;

namespace OzhanCoreLayer.ViewModels.PermissionsViewModels
{
    public class RoleIndex : IIndexVm<byte>
    {
        [Display(Name = "شرح نقش")]
        [Required]
        [MaxLength(150)]
        public string Title { get; set; }
    }

    public class RoleCreateVm
    {
        [Required]
        public byte RoleId { get; set; }

        [Display(Name = "شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; }

    }

    public class RoleEditVM
    {
        [Required]
        public byte Id { get; set; }
        [Display(Name = "شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; }
    }
}
