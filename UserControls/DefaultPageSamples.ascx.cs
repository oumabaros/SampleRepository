using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SamplesRepository.UserCode;

namespace SamplesRepository.UserControls
{
    public partial class DefaultPageSamples : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PopulateControls();
        }

        private void PopulateControls()
        {
            // Retrieve DivisionID from the query string
            string Id = Request.QueryString["Id"];
            // Retrieve Page from the query string
            string page = Request.QueryString["Page"];
            if (page == null) page = "1";
            // How many pages of products?
            int howManyPages = 1;
            // pager links format
            string firstPageUrl = "";
            string pagerFormat = "";


            if (Id == null)
            {
                // Retrieve list of samples in division
                list.DataSource = CatalogAccess.GetAllSamples(page, out howManyPages);
                list.DataBind();
                // get first page url and pager format
                firstPageUrl = Link.ToDivision(Id, "1");
                pagerFormat = Link.ToDivision(Id, "{0}");
            }

            // Display pager controls
            topPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, false);
            bottomPager.Show(int.Parse(page), howManyPages, firstPageUrl, pagerFormat, true);
        }
    }
}