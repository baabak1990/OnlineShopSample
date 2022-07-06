using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OzhanDomainLayer.Entities.Accounts.BaseClass;

namespace OzhanDomainLayer.Entities.Accounts.User
{
    public class Role
    {
        //ToDo : hamishe in sefato balaye kelid bede ke be chokh nare
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public bool IsDeleted { get; set; }
        [Display(Name = "شرح")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string Title { get; set; }


        #region Relation

        public ICollection<UserRoles> UserRoles { get; set; }
        public ICollection<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
