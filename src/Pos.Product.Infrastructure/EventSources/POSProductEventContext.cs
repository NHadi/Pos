using Dermayon.Infrastructure.Data.MongoRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pos.Product.Infrastructure.EventSources
{
    public class POSProductEventContext : MongoContext
    {
        public POSProductEventContext(POSProductEventContextSetting setting): base(setting)
        {

        }
    }
}
