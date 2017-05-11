using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using Microsoft.AspNet.SignalR;
using WebApplication1.Entities;
using WebApplication1.Models;
using WebGrease.Css.Extensions;

namespace WebApplication1.Hubs
{
    public class LiveMonitorHub : Hub
    {
        public void GetUpdatedData()
        {

            TestDB1Entities2 nimasEntities = new TestDB1Entities2();

            var list = (from m in nimasEntities.LinesMonitorings
                        join v in nimasEntities.LinesMonitoringVGs on m.VGIP equals v.VGIP
                        //let firstId = (from n in nimasEntities.LinesMonitorings where n.VGIP == m.VGIP && n.IsUp.Value select n.Id).FirstOrDefault()
                        where m.IsUp.Value /*&& m.Id == firstId*/
                        select new { m.VGIP, m.PortIndex, m.NB, m.StartDate, m.EndDate }).ToList();

            var result = list.GroupBy(n => new { n.VGIP }).Select(g => new
            {
                VGIP = g.Key,
                PortInfo = g.Select(p => new { p.PortIndex, p.NB, Uptime = (DateTime.Now - p.StartDate.GetValueOrDefault()).Duration().ToString(@"hh\:mm\:ss") })
            });
            Clients.All.update(result);
        }

        public void GetLayoutInfo()
        {
            TestDB1Entities2 nimasEntities = new TestDB1Entities2();
            var list = (from v in nimasEntities.LinesMonitoringVGs
                        join p in nimasEntities.LinesMonitoringPorts on v.Id equals p.VGID
                        select new { v.VGIP, p.PortName, p.PortIndex, v.VGName }).ToList();

            var result = list.GroupBy(n => new { n.VGIP, n.VGName }).Select(g => new
            {
                g.Key.VGIP,
                g.Key.VGName,
                PortInfo = g.Select(p => new { p.PortIndex, p.PortName })
            });

            Clients.All.updateLayout(result);
        }

    }
}