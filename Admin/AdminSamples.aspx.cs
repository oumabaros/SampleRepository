using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using SamplesRepository.UserCode;
using System.Web.UI.WebControls;
using System.Globalization;

namespace SamplesRepository.Admin
{
    public partial class AdminSamples : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        public void BindGrid()
        {
            grid.DataSource = CatalogAccess.GetSamples();
            grid.DataBind();
        }

        protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Set the row for which to enable edit mode
            grid.EditIndex = e.NewEditIndex;
            // Set status message
            statusLabel.Text = "Editing row # " + e.NewEditIndex.ToString();
            // Reload the grid
            BindGrid();
        }

        protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            // Cancel edit mode
            grid.EditIndex = -1;
            // Set status message
            statusLabel.Text = "Editing canceled";
            // Reload the grid
            BindGrid();
        }

        protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Retrieve updated data
                string id = grid.DataKeys[e.RowIndex].Value.ToString();
               
                //string refNum = ((TextBox)grid.Rows[e.RowIndex].Cells[0].Controls[0]).Text;
                string refName = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtRefNumber")).Text;
                string imageUrl = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtImageUrl")).Text;
                DateTime dateReceived =DateTime.Parse( ((TextBox)grid.Rows[e.RowIndex].FindControl("txtDateReceived")).Text);
                string type = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtType")).Text;
                string owner = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtOwner")).Text;
                string origin = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtOrigin")).Text;
                string brought = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtBrought")).Text;
                int division = Int32.Parse(((DropDownList)grid.Rows[e.RowIndex].FindControl("divisionList")).SelectedItem.Value);
                int gender = Int32.Parse(((DropDownList)grid.Rows[e.RowIndex].FindControl("lstGender")).SelectedItem.Value);
                int usage = Int32.Parse(((DropDownList)grid.Rows[e.RowIndex].FindControl("lstUsage")).SelectedItem.Value);
                bool ret = ((CheckBox)grid.Rows[e.RowIndex].FindControl("chkReturnable")).Checked;
                

                


                // Execute the update command
                bool success = CatalogAccess.UpdateSample(id, refName,imageUrl,dateReceived, type, owner, origin, brought, division, gender, ret, usage);
                //Cancel edit mode
                grid.EditIndex = -1;
                // Display status message
                statusLabel.Text = success ? "Update successful" : "Update failed";
                
            }
            catch
            {
                //Display the error
                statusLabel.Text = "Sample Update Failed";

            }

            // Reload the grid
            BindGrid();
            
           
        }

        protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Get the ID of the record to be deleted
            string id = grid.DataKeys[e.RowIndex].Value.ToString();
            // Execute the delete command
            bool success = CatalogAccess.DeleteSample(id);
            // Cancel edit mode
            grid.EditIndex = -1;
            // Display status message
            statusLabel.Text = success ? "Delete successful" : "Delete failed";
            // Reload the grid
            BindGrid();
        }

        protected void calControl_SelectionChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string t1 = grid.Rows[i].Cells[1].Text;
                //TextBox txtQtyval1 = (TextBox)grid.Rows[i].Cells[1].FindControl("txtDateReceived");
                TextBox txtDateReceived = grid.Rows[i].FindControl("txtDateReceived") as TextBox;
                System.Web.UI.WebControls.Calendar calControl=grid.Rows[i].FindControl("calDate") as System.Web.UI.WebControls.Calendar;
                txtDateReceived.Text = Convert.ToDateTime(calControl.SelectedDate, CultureInfo.GetCultureInfo("en-US")).ToString("MM/dd/yyyy");
            }
            
            
        }

        protected void createSample_Click(object sender, EventArgs e)
        {
            string refNumber=txtRefNumber.Text;
            DateTime sDate =DateTime.Parse( txtDate.Text);
            string sType = txtType.Text;
            string ownersName = txtOwner.Text;
            string origin = txtOrigin.Text;
            string broughtBy = txtBrought.Text;
            string image = txtImage.Text;
            int division =Int32.Parse(cboDivision.SelectedItem.Value);
            int gender =Int32.Parse(cboGender.SelectedItem.Value);
            bool returnable = chkReturnable.Checked;
            int usage =Int32.Parse(cboUsage.SelectedItem.Value);

            

            // Execute the insert command
            bool success = CatalogAccess.AddSample(refNumber,sDate,sType,ownersName,origin,broughtBy,image,division,
                gender,returnable,usage);
            // Display status message
            statusLabel.Text = success ? "Insert successful" : "Insert failed";
            ClearFields();
            // Reload the grid
            BindGrid();
        }

        protected void ClearFields()
        {
            txtRefNumber.Text="";
            txtDate.Text="";
            txtType.Text="";
            txtOwner.Text="";
            txtOrigin.Text="";
            txtBrought.Text="";
            txtImage.Text="";
            chkReturnable.Checked=false;
            
        }
        protected void upload1Button_Click(object sender, EventArgs e)
        {
            // proceed with uploading only if the user selected a file
            if (image1FileUpload.HasFile)
            {
                try
                {
                    string fileName = image1FileUpload.FileName;
                    string location = HttpContext.Current.Server.MapPath("~/SampleImgs/") + fileName;
                    // save image to server
                    image1FileUpload.SaveAs(location);
                    txtImage.Text = fileName;
                    // update database with new product details
                }
                catch
                {
                    statusLabel.Text = "Uploading image 1 failed";
                }
            }
        }

        
    }
}