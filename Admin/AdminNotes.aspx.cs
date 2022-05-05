using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SamplesRepository.UserCode;
using System.Data;
using System.Data.Common;

namespace SamplesRepository.Admin
{
    public partial class AdminNotes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                BindData();

            }
        }

        public void BindData()
        {
            string Id = Request.QueryString["Id"];

            DataTable Note = CatalogAccess.GetNoteDetailsBySampleId(Id);
            grid.DataSource = Note;
            grid.DataBind();
        }

        protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row for which to enable edit mode
            grid.EditIndex = e.NewEditIndex;
            // Set status message
            statusLable.Text = "Editing row # " + e.NewEditIndex.ToString();
            // Reload the grid
            BindData();
        }

        protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            grid.EditIndex = -1;
            // Set status message
            statusLable.Text = "Editing canceled";
            // Reload the grid
            BindData();
        }

        protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Retrieve updated data
            string id = grid.DataKeys[e.RowIndex].Value.ToString();
            string baseColor = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtBaseColor")).Text;
            string designDetails = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtDesignDetails")).Text;
            string size = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtSize")).Text;
            string weight = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtWeight")).Text;
            string status = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtStatus")).Text;
            string productionSchedule = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtProductionSchedule")).Text;
            string ETAMarket = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtETAMarket")).Text;
            string color = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtColor")).Text;
            string typeOfKnitWeave = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtTypeOfKnitWeave")).Text;
            bool fullSleeve = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkFullSleeve")).Checked;
            bool sleeveless = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkSleeveless")).Checked;
            bool heavyWeight = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkHeavyWeight")).Checked;
            bool mediumWeight = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkMediumWeight")).Checked;
            bool lightWeight = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkLightWeight")).Checked;
            string additionalNotes = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtAdditionalNotes")).Text;
            bool embroideredEmblem = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkEmbroideredEmblem")).Checked;
            bool vNeckFront = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkVNeckFront")).Checked;
            string finishingDetails = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtFinishingDetails")).Text;

            // Execute the update command
            bool success = CatalogAccess.UpdateNoteDetails(id,baseColor,designDetails,size,weight,status,
                productionSchedule,ETAMarket,color,typeOfKnitWeave,fullSleeve,sleeveless,heavyWeight,
                mediumWeight,lightWeight,additionalNotes,embroideredEmblem,vNeckFront,finishingDetails);
            //Cancel edit mode
            grid.EditIndex = -1;
            // Display status message
            statusLable.Text = success ? "Update successful" : "Update failed";


            }

            catch
            {
                //Display the error
                statusLable.Text = "Sample Update Failed";
            }

            BindData();
            
        }

        protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the ID of the record to be deleted
            string id = grid.DataKeys[e.RowIndex].Value.ToString();
            // Execute the delete command
            bool success = CatalogAccess.DeleteNoteDetails(id);
            // Cancel edit mode
            grid.EditIndex = -1;
            // Display status message
            statusLable.Text = success ? "Delete successful" : "Delete failed";
            // Reload the grid
            BindData();
        }

        protected void createNotes_Click(object sender, EventArgs e)
        {
            int sample_id=Int32.Parse(Request.QueryString["Id"]);
            string baseColor = BaseColor.Text;
            string designDetails = DesignDetails.Text;
            string size = Size.Text;
            string weight = Weight.Text;
            string status = Status.Text;
            string schedule = ProductionSchedule.Text;
            string etamarket = ETAMarket.Text;
            string color = Color.Text;
            string type = TypeOfKnitWeave.Text;
            bool fullSleeve = FullSleeve.Checked;
            bool sleeveless = Sleeveless.Checked;
            bool heavyWeight = HeavyWeight.Checked;
            bool mediumWeight = MediumWeight.Checked;
            bool lightWeight = LightWeight.Checked;
            string additionalNotes = AdditionalNotes.Text;
            bool embroidered = EmbroideredEmblem.Checked;
            bool vneckFront =VNeckFront.Checked;
            string finishingDetails = FinishingDetails.Text;


            // Execute the insert command
            bool success = CatalogAccess.AddNote(baseColor,designDetails,size,weight,status,sample_id,schedule,etamarket,color,type,
                fullSleeve,sleeveless,heavyWeight,mediumWeight,lightWeight,additionalNotes,embroidered,vneckFront,finishingDetails);
            // Display status message
            statusLable.Text = success ? "Insert successful" : "Insert failed";
            ClearFields();
            // Reload the grid
            BindData();
        }

        protected void ClearFields()
        {
            BaseColor.Text="";
            DesignDetails.Text="";
            Size.Text="";
            Weight.Text="";
            Status.Text="";
            ProductionSchedule.Text="";
            ETAMarket.Text="";
            Color.Text="";
            TypeOfKnitWeave.Text="";
            FullSleeve.Checked=false;
            Sleeveless.Checked=false;
            HeavyWeight.Checked=false;
            MediumWeight.Checked=false;
            LightWeight.Checked=false;
            AdditionalNotes.Text="";
            EmbroideredEmblem.Checked=false;
            VNeckFront.Checked=false;
            FinishingDetails.Text="";
        }
    }
}