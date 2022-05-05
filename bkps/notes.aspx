<div class="container">
          <div class="row">
            <div class="col-md-8">
              <b>Note Details</b>
              <div class="row">
                <div class="col-md-6 col-1">Base Color:</div><div class="col-md-6 col-2"><asp:TextBox ID="txtRefNumber" runat="server" Text='<%# Bind("BaseColor") %>'></asp:TextBox></div>
                <div class="col-md-6 col-1">Design Details:</div><div class="col-md-6 col-2"> <%# Eval("DesignDetails") %></div>
                <div class="col-md-6 col-1">Size:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("Size").ToString()) %></div>
                <div class="col-md-6 col-1">Weight:</div><div class="col-md-6 col-2"><%# Eval("Weight") %></div>
                <div class="col-md-6 col-1">Status:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("Status").ToString()) %></div>
                <div class="col-md-6 col-1">Production Schedule:</div><div class="col-md-6 col-2"> <%# Eval("ProductionSchedule") %></div>
                <div class="col-md-6 col-1 ">ETAMarket</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("ETAMarket").ToString()) %></div>
                <div class="col-md-6 col-3">Product Category by:</div><div class="col-md-6"></div>
                <div class="col-md-6 col-1">Color</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("Color").ToString()) %></div>
                <div class="col-md-6 col-1">Type of Knitweave</div><div class="col-md-6 col-2" > <%# HttpUtility.HtmlEncode(Eval("TypeOfKnitWeave").ToString()) %></div>
                <div class="col-md-6 col-1">Full Sleeve:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("FullSleeve").ToString()) %></div>
                <div class="col-md-6 col-3 ">Additional Notes:</div><div class="col-md-6"></div>
                <div class="col-md-6 col-1">Sleveless:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("Sleeveless").ToString()) %></div>
                <div class="col-md-6 col-1">HeavyWeight:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("HeavyWeight").ToString()) %></div>
                <div class="col-md-6 col-1">MediumWeight:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("MediumWeight").ToString()) %></div>
                <div class="col-md-6 col-1">LightWeight:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("LightWeight").ToString()) %></div>
                <div class="col-md-6 col-1">Additional Notes:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("AdditionalNotes").ToString()) %></div>
                <div class="col-md-6 col-1">Embroidered Emblem:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("EmbroideredEmblem").ToString()) %></div>
                <div class="col-md-6 col-1">VNeckFront:</div><div class="col-md-6 col-2"> <%# HttpUtility.HtmlEncode(Eval("VNeckFront").ToString()) %></div>
                <div class="col-md-6 col-1">Finish Details:</div><div class="col-md-6 col-2"><%# HttpUtility.HtmlEncode(Eval("FinishingDetails").ToString()) %></div>
              </div>
            </div>
            </div>
        </div>
		
		
		//DataRow drow=Note.Rows[0];
            foreach (DataRow row in Note.Rows)
            {
                //lblBaseColor.Text = row["BaseColor"].ToString();
            }
            
            //string DesignDetails = Note.De;
            //string Size = Note.Size;
            //string Weight = Note.Size;
            //string Status = Note.Size;
            //int Sample_Id = Note.Sample_Id;
            //string ProductionSchedule = Note.ProductionSchedule;
            //string ETAMarket = Note.ETAMarket;
            //string Color = Note.Color;
            //string TypeOfKnitWeave = Note.TypeOfKnitWeave;
            //string FullSleeve = Note.FullSleeve;
            //string Sleeveless = Note.Sleeveless;
            //string HeavyWeight = Note.MediumWeight;
            //string MediumWeight = Note.MediumWeight;
            //string LightWeight = Note.LightWeight;
            //string AdditionalNotes = Note.AdditionalNotes;
            //string EmbroideredEmblem = Note.EmbroideredEmblem;
            //string VNeckFront = Note.VNeckFront;
            //string FinishingDetails = Note.FinishingDetails;

        }