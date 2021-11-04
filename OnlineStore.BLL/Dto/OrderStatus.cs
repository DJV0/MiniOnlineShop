using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStore.BLL.Dto
{
    public enum OrderStatus
    {
        New,
        Canceled_by_user,
        Canceled_by_the_administrator,
        Payment_received,
        Sent,
        Received,
        Completed
    }
}
