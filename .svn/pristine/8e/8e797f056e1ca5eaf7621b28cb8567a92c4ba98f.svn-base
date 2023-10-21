using RTH.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Business.Objects.JSON
{
    public partial class Engagement : NotifyBase
    {
        public Engagement()
        {
            Engagement.Index = 0;
        }
        public string user_id { get; set; }
        public string activity_id { get; set; }
        public string option_id { get; set; }
        public string option { get; set; }
        public string additional_info { get; set; }
        public string client_offset { get; set; }
        public string client_date { get; set; }
        public string _id
        {
            get { return GetValue(() => _id); }
            set { SetValue(() => _id, value); }
        }

        public static int Index = 0;

        public int RowNo
        {
            get { return ++Index; }
        }
        public string when_required_server
        {
            get { return GetValue(() => when_required_server); }
            set { SetValue(() => when_required_server, value); }
        }
        public string when_responded_server
        {
            get { return GetValue(() => when_responded_server); }
            set { SetValue(() => when_responded_server, value); }
        }
        public string when_required_user
        {
            get { return GetValue(() => when_required_user); }
            set { SetValue(() => when_required_user, value); }
        }
        public string when_responded_user
        {
            get { return GetValue(() => when_responded_user); }
            set { SetValue(() => when_responded_user, value); }
        }
        public string push_type
        {
            get { return GetValue(() => push_type); }
            set { SetValue(() => push_type, value); }
        }
        public string engage_category
        {

            get { return GetValue(() => engage_category); }
            set { SetValue(() => engage_category, value); }
        }
        public string engage_icon
        {
            get { return GetValue(() => engage_icon); }
            set { SetValue(() => engage_icon, value); }
        }
        public string engage_statement
        {
            get { return GetValue(() => engage_statement); }
            set { SetValue(() => engage_statement, value); }
        }
        public object Tag
        {
            get { return GetValue(() => Tag); }
            set { SetValue(() => Tag, value); }
        }
        public string CategoryImageUrl
        {
            get
            {
                return Config.ApiUrl + category_image;
            }
        }
        public string category_image { get; set; }
        public string thread { get; set; }
        public int? chevron_link { get; set; }
        public string chevron_obj { get; set; }
    }


    public class UserTimeline
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<Engagement> engagements { get; set; }
    }
}
