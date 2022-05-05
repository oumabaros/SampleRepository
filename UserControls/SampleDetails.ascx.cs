using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SamplesRepository.UserCode;

namespace SamplesRepository.UserControls
{
    public partial class SampleDetails : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        private void PopulateControls()
        {
            // Retrieve DivisionID from the query string
            string Id = Request.QueryString["Id"];
            
            if (Id != null)
            {
                // Retrieve list of samples in division
                list.DataSource = CatalogAccess.GetSampleDetails(Id);
                list.DataBind();
               
            }

            
        }
    }
}