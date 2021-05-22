using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyer.Core.Models
{
    public class MsgTemplateField
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserText { get; set; }
        public int Size { get; set; }
        public bool IsRequired { get; set; }
        public bool IsNumeric { get; set; }

        public string TextBefore { get; set; }
        public string TextAfterIf { get; set; }
        public string TextAfterElse { get; set; }
        public string TextAfterValueToCompare { get; set; }
    }
}
