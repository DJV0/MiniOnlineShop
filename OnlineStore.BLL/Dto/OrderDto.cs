using OnlineStore.BLL.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Dto
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public DateTime DateTime { get; set; }
        public RegisteredUser User { get; set; }
        public List<ProductDto> Products { get; set; }
        public OrderStatus Status { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Дата: {DateTime}, Статус: {Status}";
        }
    }
}
