using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Entities;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DeviceRegistrationsController : Controller
    {
        private TestDB1Entities2 db = new TestDB1Entities2();


        public ActionResult GetUpdatedData(string PhoneType)
        {
            List<DeviceRegistration> reg = null;
            switch (PhoneType)
            {
                case "Desk":
                    reg = db.DeviceRegistrations.Where(t => t.Name.StartsWith("SEP")).OrderByDescending(s => s.RegDateTime).Take(1).ToList();
                    break;

                case "Jabber":
                    reg = db.DeviceRegistrations.Where(t => t.Name.StartsWith("TCT") || t.Name.StartsWith("BOT") || t.Name.StartsWith("CSF")).OrderByDescending(s => s.RegDateTime).Take(1).ToList();
                    break;

                default:
                    reg = db.DeviceRegistrations.OrderByDescending(s => s.RegDateTime).Take(1).ToList();
                    break;
            }

            List<DeviceRegistrationView> drr = new List<DeviceRegistrationView>();
            DeviceRegistrationView dv;
            foreach (var a in reg)
            {
                dv = new DeviceRegistrationView()
                {
                    Id = a.Id,
                    Status = a.Status,
                    Name = a.Name,
                    IP = a.IP
                };
                var t = from type in db.DeviceTypes
                        where type.DeviceEnum == a.Type
                        select type.DeviceName;
                dv.Type = t.FirstOrDefault();
                dv.Description = a.Description;
                if (a.Reason != null)
                {
                    var x = from reason in db.DeviceRegistrationReasons
                            where reason.Reason == a.Reason
                            select reason;
                    dv.Reason = x.FirstOrDefault().Definition;
                    dv.ReasonDescription = x.FirstOrDefault().Details;
                }
                else dv.Reason = "";
                dv.DN = a.DN;
                dv.Firmware = a.Firmware;
                dv.RegDate = a.RegDateTime.Date;
                dv.RegTime = a.RegDateTime;   //DateTime.Parse(a.RegDateTime.ToString("HH:mm"));
                drr.Add(dv);
            }
            return PartialView("_DeviceUpdate", drr);
        }


        public ActionResult GetData(string PhoneType, int SkipRows, string LastGroup)
        {
            List<DeviceRegistration> reg = null;
            switch (PhoneType)
            {
                case "Desk":
                    reg = db.DeviceRegistrations.Where(t => t.Name.StartsWith("SEP")).OrderByDescending(s => s.RegDateTime).Skip(SkipRows).Take(10).ToList();
                    break;

                case "Jabber":
                    reg = db.DeviceRegistrations.Where(t => t.Name.StartsWith("TCT") || t.Name.StartsWith("BOT") || t.Name.StartsWith("CSF")).OrderByDescending(s => s.RegDateTime).Skip(SkipRows).Take(10).ToList();
                    break;

                default:
                    reg = db.DeviceRegistrations.OrderByDescending(s => s.RegDateTime).Skip(SkipRows).Take(10).ToList();
                    break;
            }

            List<DeviceRegistrationView> drr = new List<DeviceRegistrationView>();
            DeviceRegistrationView dv;
            foreach (var a in reg)
            {
                dv = new DeviceRegistrationView()
                {
                    Id = a.Id,
                    Status = a.Status,
                    Name = a.Name,
                    IP = a.IP
                };
                var t = from type in db.DeviceTypes
                        where type.DeviceEnum == a.Type
                        select type.DeviceName;
                dv.Type = t.FirstOrDefault();
                dv.Description = a.Description;
                if (a.Reason != null)
                {
                    var x = from reason in db.DeviceRegistrationReasons
                            where reason.Reason == a.Reason
                            select reason;
                    dv.Reason = x.FirstOrDefault().Definition;
                    dv.ReasonDescription = x.FirstOrDefault().Details;
                }
                else dv.Reason = "";
                dv.DN = a.DN;
                dv.Firmware = a.Firmware;
                dv.RegDate = a.RegDateTime.Date;
                dv.RegTime = a.RegDateTime;   //DateTime.Parse(a.RegDateTime.ToString("HH:mm"));
                drr.Add(dv);
            }
            var group = drr.GroupBy(item => item.RegDate).ToList();

            var model = new DeviceRegistrationUpdateModel();
            foreach (var item in group)
            {
                if (item.Key.ToString("dd MMM").Equals(LastGroup))
                {
                    model.ExistingGroupList = item.ToList();
                    group.Remove(item);
                    break;
                }
            }
            model.GroupList = group;
            return PartialView("_DeviceUpdateWithGroup", model);

        }


        public ActionResult Registration(string PhoneType)
        {
            List<DeviceRegistration> reg = null;
            switch (PhoneType)
            {
                case "Desk":
                    reg = db.DeviceRegistrations.Where(t => t.Name.StartsWith("SEP")).OrderByDescending(s => s.RegDateTime).Take(10).ToList();
                    break;

                case "Jabber":
                    reg = db.DeviceRegistrations.Where(t => t.Name.StartsWith("TCT") || t.Name.StartsWith("BOT") || t.Name.StartsWith("CSF")).OrderByDescending(s => s.RegDateTime).Take(10).ToList();
                    break;

                default:
                    reg = db.DeviceRegistrations.OrderByDescending(s => s.RegDateTime).Take(10).ToList();
                    break;
            }

            List<DeviceRegistrationView> drr = new List<DeviceRegistrationView>();
            DeviceRegistrationView dv;
            foreach (var a in reg)
            {
                dv = new DeviceRegistrationView();
                dv.Id = a.Id;
                dv.Status = a.Status;
                dv.Name = a.Name;
                dv.IP = a.IP;
                var t = from type in db.DeviceTypes
                        where type.DeviceEnum == a.Type
                        select type.DeviceName;
                dv.Type = t.FirstOrDefault();
                dv.Description = a.Description;
                if (a.Reason != null)
                {
                    var x = from reason in db.DeviceRegistrationReasons
                            where reason.Reason == a.Reason
                            select reason;
                    dv.Reason = x.FirstOrDefault().Definition;
                    dv.ReasonDescription = x.FirstOrDefault().Details;
                }
                else dv.Reason = "";
                dv.DN = a.DN;
                dv.Firmware = a.Firmware;
                dv.RegDate = a.RegDateTime.Date;
                dv.RegTime = a.RegDateTime;   //DateTime.Parse(a.RegDateTime.ToString("HH:mm"));
                drr.Add(dv);
            }
            return View(drr);
        }

    }
}
