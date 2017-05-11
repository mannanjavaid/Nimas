using DropdownGrid.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using WebApplication1.Reports;
using WebApplication1.Reports.CdrDataSetTableAdapters;
using WebApplication1.Reports.CmrDataSetTableAdapters;

namespace WebApplication1.Controllers
{
    public class JSONDataController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\CdrDataReport.rdlc";
            reportViewer.ZoomMode = ZoomMode.FullPage;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            var dataSet = new CdrDataSet();
            var da = new CdrDataTableAdapter().GetData();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("CdrDataSet", da.ToList()));
            ViewBag.ReportViewer = reportViewer;
            return View();
        }

        public ActionResult Report1()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Reports\CmrDataReport.rdlc";
            reportViewer.ZoomMode = ZoomMode.FullPage;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);

            var dataSet = new CmrDataSet();
            var da = new WebApplication1.Reports.CmrDataSetTableAdapters.cmrdataTableAdapter().GetData();
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("CmrDataSet", da.ToList()));
            ViewBag.ReportViewer = reportViewer;
            return View();
        }


    }
}