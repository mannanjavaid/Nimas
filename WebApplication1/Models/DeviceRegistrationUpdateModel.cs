using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Model;

namespace WebApplication1.Models
{
    public class DeviceRegistrationUpdateModel
    {
        public DeviceRegistrationUpdateModel()
        {
            ExistingGroupList = new List<DeviceRegistrationView>();
            GroupList = new List<IGrouping<DateTime, DeviceRegistrationView>>();
        }
        public List<DeviceRegistrationView> ExistingGroupList { get; set; }
        public List<IGrouping<DateTime, DeviceRegistrationView>> GroupList { get; set; }
    }
}