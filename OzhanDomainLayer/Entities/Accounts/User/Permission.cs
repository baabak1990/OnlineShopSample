using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Accounts.User
{
    public class Permission
    {
        [Key] public int Id { get; set; }
        [Display(Name = "شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Title { get; set; }
        public int? ParentId { get; set; }

        #region Relations

        public ICollection<RolePermission> RolePermissions { get; set; }

        [ForeignKey("ParentId")]
        public List<Permission> Permissions { get; set; }
        #endregion
    }
}
