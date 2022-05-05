using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SamplesRepository.UserCode;

namespace SamplesRepository.UserControls
{
    public partial class DivisionList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // CatalogAccess.GetDivisionss returns a DataTable object containing
            // division data, which is read in the ItemTemplate of the DataList
            list.DataSource = CatalogAccess.GetDivisions();
            // Needed to bind the data bound controls to the data source
            list.DataBind();
        }
    }
}