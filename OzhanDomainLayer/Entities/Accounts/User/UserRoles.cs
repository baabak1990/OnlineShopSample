using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OzhanDomainLayer.Entities.Accounts.User
{
    public class UserRoles
    {
        public long User_Id { get; set; }
        public byte RoleP_Id { get; set; }



        public User User { get; set; }
        public Role Role { get; set; }
    }
}
