using RTH.Business.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTH.Windows.Views.Objects
{
    public class AppVersionInfo : VersionInfo
    {
        public AppVersionInfo(VersionInfo info)
        {
            __v = info.__v;
            _id = info._id;
            build = info.build;
            created = info.created;
            deleted = info.deleted;
            force_update = info.force_update;
            is_latest_version = info.is_latest_version;
            message = info.message;
            platform = info.platform;
            release_date = info.release_date;
            user = info.user;
            version = info.version;
        }
        public Enums.AppVersions AppVersion { get; set; }
    }
}
