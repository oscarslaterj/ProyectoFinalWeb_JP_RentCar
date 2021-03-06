﻿using Microsoft.Reporting.WebForms;
using ProyectoFinalWeb_JPRentACar.UI.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinalWeb_JPRentACar.UI.Reportes
{
    public partial class VehiculosReportViewer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ListadoReportViewer.ProcessingMode = ProcessingMode.Local;
                ListadoReportViewer.Reset();
                ListadoReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\UI\Reportes\VehiculosReport.rdlc");
                ListadoReportViewer.LocalReport.DataSources.Clear();
                ListadoReportViewer.LocalReport.DataSources.Add(new ReportDataSource("VehiculosDataSet", cVehiculos.listVehiculos));
                ListadoReportViewer.LocalReport.Refresh();
            }
        }
    }
}