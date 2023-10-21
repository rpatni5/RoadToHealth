using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects.JSON
{
    public class ConversationThread
    {
        public string _id { get; set; }
        public string engage_category { get; set; }
        public string engage_icon { get; set; }
        public string engage_statement { get; set; }
        public string category_image { get; set; }
        public List<OptionList> option_list { get; set; }
        public int chevron_link { get; set; }
        public string chevron_obj { get; set; }
    }

    public class OptionList
    {
        public string option_id { get; set; }
        public string option { get; set; }
        public string imageName { get; set; }
        public int additional_info { get; set; }
    }
}
