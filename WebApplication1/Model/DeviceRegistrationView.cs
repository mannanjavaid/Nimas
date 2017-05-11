using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Model
{
    public class DeviceRegistrationView
    {
        public int Id { get; set; }
        public Nullable<Boolean> Status { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Reason { get; set; }
        public string ReasonDescription { get; set; }
        public string Firmware { get; set; }
        public string DN { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMMM}")]
        public DateTime RegDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:HH:mm}")]
        public DateTime RegTime { get; set; }
    }
}