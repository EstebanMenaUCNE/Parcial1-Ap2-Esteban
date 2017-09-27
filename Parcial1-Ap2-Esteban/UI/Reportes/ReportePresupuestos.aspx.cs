using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial1_Ap2_Esteban.UI.Reportes
{
    public partial class ReportePresupuestos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReportViewer.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
                ReportViewer.Reset();
                ReportViewer.LocalReport.ReportPath = Server.MapPath(@"ReportePresupuestos.rdlc");
                ReportViewer.LocalReport.DataSources.Clear();
                ReportViewer.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSetPresupuestos", Consultas.ConsultaPresupuestos.Lista));
                ReportViewer.LocalReport.Refresh();
            }
        }
    }
}