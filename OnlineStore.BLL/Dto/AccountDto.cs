using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Dto
{
    public class AccountDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Имя: {Name}, Фамилия: {LastName}, Login: {Login}, Password: {Password}";
        }
    }
}
