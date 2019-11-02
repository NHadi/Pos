using Dermayon.Common.Domain;
using System;
using System.Collections.Generic;

namespace Pos.Customer.Domain.CustomerAggregate
{
    public partial class MstCustomer : EntityBase
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}