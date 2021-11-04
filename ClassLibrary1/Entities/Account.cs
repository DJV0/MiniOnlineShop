using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.DAL.Entities
{
    public class Account : TEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }
}
