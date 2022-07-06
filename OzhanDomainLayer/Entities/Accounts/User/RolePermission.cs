using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Accounts.User
{
    public class RolePermission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte RP_Id { get; set; }
        public byte Role_Id { get; set; }
        public int Permission_Id { get; set; }



        public Role Role { get; set; }
        public Permission Permission { get; set; }
    }
}
