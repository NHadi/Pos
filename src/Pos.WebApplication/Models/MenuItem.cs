using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.WebApplication.Models
{
    public class MenuItem
    {
        public Guid Id { get; set; }
        public Guid? Parent { get; set; }
        public string Title { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public int Position { get; set; }
        public bool OpenInNewWindow { get; set; }
    }
}
