using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_projo.Models
{
    public static class MockDatabase
    {
        public static List<UserModel> Users { get; set; } = new List<UserModel>
        {
            new UserModel { Username = "admin", Password = "123" },
            new UserModel { Username = "dyrektor", Password = "haslo1"},
            new UserModel { Username = "klient", Password = "klient" }
        };
    }
}
