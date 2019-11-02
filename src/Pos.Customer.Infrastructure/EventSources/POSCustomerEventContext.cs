using Dermayon.Infrastructure.Data.MongoRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Customer.Infrastructure.EventSources
{
    public class POSCustomerEventContext : MongoContext
    {
        public POSCustomerEventContext(POSCustomerEventContextSetting setting) : base(setting)
        {
                
        }
    }
}
