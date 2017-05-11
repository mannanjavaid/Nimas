using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AuditController : Controller
    {
        public ActionResult Index()
        {
            //    List<CUCMAudit> aud = null;
            //    aud = db.CUCMAudits.OrderByDescending(s => s.AuditDateTime).Take(1).ToList();
            //    List<AuditView> av = new List<AuditView>();
            //    AuditView dv;
            //    foreach (var a in aud)
            //    {
            //        dv = new AuditView();
            //        dv.Id = a.Id;
            //        dv.UserID = a.UserID;
            //        dv.Severity = a.Severity;
            //        dv.EventStatus = a.EventStatus;
            //        dv.IP = a.IP;
            //        dv.EventType = a.EventType;
            //        dv.AuditDetails = a.AuditDetails;
            //        dv.AuditDate = a.AuditDateTime.Date;
            //        dv.AuditTime = a.AuditDateTime;

            //        if (dv.Severity > 3)
            //        {
            //            av.Add(dv);
            //        }
            //    }
            //    return PartialView("_AuditUpdate", av);
            //}
            //public ActionResult GetAuditData(int SkipRows, string LastGroup)
            //{
            //    List<CUCMAudit> aud = null;

            //    aud = db.CUCMAudits.OrderByDescending(s => s.AuditDateTime).Skip(SkipRows).Take(10).ToList();

            //    List<AuditView> av = new List<AuditView>();
            //    AuditView dv;
            //    foreach (var a in aud)
            //    {
            //        dv = new AuditView();
            //        dv.Id = a.Id;
            //        dv.UserID = a.UserID;
            //        dv.Severity = a.Severity;
            //        dv.EventStatus = a.EventStatus;
            //        dv.IP = a.IP;
            //        dv.EventType = a.EventType;
            //        dv.AuditDetails = a.AuditDetails;
            //        dv.AuditDate = a.AuditDateTime.Date;
            //        dv.AuditTime = a.AuditDateTime;

            //        if (dv.Severity > 3)
            //        {
            //            av.Add(dv);
            //        }
            //        av.Add(dv);
            //    }
            //    var group = av.GroupBy(item => item.AuditDate).ToList();

            //    var model = new AuditUpdateModel();
            //    foreach (var item in group)
            //    {
            //        if (item.Key.ToString("dd MMM").Equals(LastGroup))
            //        {
            //            model.ExistingGroupList = item.ToList();
            //            group.Remove(item);
            //            break;
            //        }
            //    }
            //    model.GroupList = group;
            //    return PartialView("_AuditUpdateWithGroup", model);

            //}
            //public ActionResult Audit()
            //{
            //    var aud = db.CUCMAudits.OrderByDescending(s => s.AuditDateTime).Take(10).ToList();
            //    List<AuditView> av = new List<AuditView>();
            //    AuditView dv;
            //    foreach (var a in aud)
            //    {
            //        dv = new AuditView();
            //        dv.Id = a.Id;
            //        dv.UserID = a.UserID;
            //        dv.Severity = a.Severity;
            //        dv.EventStatus = a.EventStatus;
            //        dv.IP = a.IP;
            //        dv.EventType = a.EventType;
            //        dv.AuditDetails = a.AuditDetails;
            //        dv.AuditDate = a.AuditDateTime.Date;
            //        dv.AuditTime = a.AuditDateTime;

            //        if (dv.Severity > 3)
            //        {
            //            if (dv.IP != "10.1.100.24" && dv.IP != "10.1.100.21" && dv.IP != "10.1.100.23")
            //            {
            //                av.Add(dv);
            //            }
            //        }
            //    }
            //    return View(av);
            return View();
        }
    }
}