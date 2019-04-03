using Microsoft.Reporting.WebForms;
using ProyectoFinalWeb_JPRentACar.UI.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb_JPRentACar.UI.Reportes
{
    public partial class UsuarioReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListadoReportViewer.ProcessingMode = ProcessingMode.Local;
                ListadoReportViewer.Reset();
                ListadoReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\UsuariosReport.rdlc");
                ListadoReportViewer.LocalReport.DataSources.Clear();
                ListadoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("UsuariosDataSet", cUsuarios.listUsuarios));
                ListadoReportViewer.LocalReport.Refresh();
            }
        }
    }
}