using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Model
{
    public class LoginAuthentication
    {
        //public int Id { get; set; }
        public Int64 Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
        public List<LoginAuthentication> LoginAuthenticationResult { get; set; }
    }

    public class UserPassowrds
    {
        public string CompanyName { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
    }

    public class UserPassowrdsSecond
    {
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
