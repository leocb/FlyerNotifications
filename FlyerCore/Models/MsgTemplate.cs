using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Core.Models
{
    public class MsgTemplate
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
        public List<MsgTemplateField> Fields { get; set; }
    }
}
