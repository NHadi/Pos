using Dermayon.Infrastructure.Data.MongoRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Order.Infrastructure.EventSources
{
    public class POSOrderEventContext : MongoContext
    {
        public POSOrderEventContext(POSOrderEventContextSetting setting) : base(setting)
        {
                
        }
    }
}
