using Microsoft.Reporting.WebForms;
using ProyectoFinalWeb_JPRentACar.UI.Registros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb_JPRentACar.UI.Reportes
{
    public partial class ReciboRentaReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ReciboReportViewer.ProcessingMode = ProcessingMode.Local;
                ReciboReportViewer.Reset();
                ReciboReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\ReciboRentaReport.rdlc");
                ReciboReportViewer.LocalReport.DataSources.Clear();
                //ReciboReportViewer.LocalReport.DataSources.Add(new ReportDataSource("RentasDataSet", rRenta.renta));
                ReciboReportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReciboDataSet", rRenta.renta.Detalle));
                ReciboReportViewer.LocalReport.Refresh();
            }
        }
    }
}