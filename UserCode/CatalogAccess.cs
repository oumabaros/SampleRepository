using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;


namespace SamplesRepository.UserCode
{
    public struct Division
    {
        public int Id;
        public string DivisionName;
    }

    /// <summary>
    /// Wraps sample details data
    /// </summary>
    public struct Sample
    {
        public int Id;
        public string RefNumber;
        public DateTime DateReceived;
        public string SampleType;
        public string OwnersName;
        public string Origin;
        public string BroughtInBy;
        public string ImageUrl;
        public int Division_Id;
        public int Gender_Id;
        public int Returnable;
        public int Usage_Id;
        

    }

    /// <summary>
    /// Wraps note details data
    /// </summary>
    public struct AdditionalNote
    {
        public int Id;
        public string BaseColor;
        public string DesignDetails;
        public string Size;
        public string Weight;
        public string Status;
        public int Sample_Id;
        public string ProductionSchedule;
        public string ETAMarket;
        public string Color;
        public string TypeOfKnitWeave;
        public string FullSleeve;
        public string Sleeveless;
        public string HeavyWeight;
        public string MediumWeight;
        public string LightWeight;
        public string AdditionalNotes;
        public string EmbroideredEmblem;
        public string VNeckFront;
        public string FinishingDetails;
        
    }

    public struct Gender
    {
        public int Id;
        public string Gen;
        
    }


    public struct Usage
    {
        public int Id;
        public string Usg;

    }

    public struct Returnable
    {
        public int Id;
        public string Status;
    }
    public static class CatalogAccess
    {
        static CatalogAccess()
        {

        }

        public static Returnable GetReturnable()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetReturnable";
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // wrap retrieved data into a SampleDetails object
            Returnable details = new Returnable();
            if (table.Rows.Count > 0)
            {
                details.Id = Int32.Parse(table.Rows[0]["Id"].ToString());
                details.Status = table.Rows[0]["Status"].ToString();

            }
            // return sample details
            return details;
        }

        public static Usage GetUsage()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetUsage";
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // wrap retrieved data into a SampleDetails object
            Usage details = new Usage();
            if (table.Rows.Count > 0)
            {
                details.Id = Int32.Parse(table.Rows[0]["Id"].ToString());
                details.Usg = table.Rows[0]["Usg"].ToString();

            }
            // return sample details
            return details;
        }

        public static Gender GetGender()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetGender";
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // wrap retrieved data into a SampleDetails object
            Gender details = new Gender();
            if (table.Rows.Count > 0)
            {
                details.Id = Int32.Parse(table.Rows[0]["Id"].ToString());
                details.Gen = table.Rows[0]["Gen"].ToString();
                
            }
            // return sample details
            return details;
        }
        public static DataTable GetDivisions()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetDivisions";
            // execute the stored procedure and return the results
            return GenericDataAccess.ExecuteSelectCommand(comm);
        }

        // get SampleDetails
        public static DataTable GetAllSamples(string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetAllSamples";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = SamplesConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts /
                           (double)SamplesConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }

        public static DataTable GetSamples()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetSamples";
            
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            
            return table;
        }
        public static DataTable GetImageUrl(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetImageUrl";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
           // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            return table;
        }

        public static DataTable GetSampleDetails(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetSampleDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            return table;
        }
        
       
        public static DataTable GetSamplesInDivision(string Id, string pageNumber, out int howManyPages)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetSamplesPerDivision";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@DivisionID";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
                        
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@PageNumber";
            param.Value = pageNumber;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductsPerPage";
            param.Value = SamplesConfiguration.ProductsPerPage;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@HowManyProducts";
            param.Direction = ParameterDirection.Output;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure and save the results in a DataTable
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // calculate how many pages of products and set the out parameter
            int howManyProducts = Int32.Parse(comm.Parameters["@HowManyProducts"].Value.ToString());
            howManyPages = (int)Math.Ceiling((double)howManyProducts /
                           (double)SamplesConfiguration.ProductsPerPage);
            // return the page of products
            return table;
        }


        // Get Note details
        public static DataTable GetNoteDetailsBySampleId(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetNoteDetailsBySampleId";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
           
            // return Note details
            return table;
        }

        // Get Note details
        public static AdditionalNote GetAllNoteDetails()
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "GetAllNoteDetails";
            
            // execute the stored procedure
            DataTable table = GenericDataAccess.ExecuteSelectCommand(comm);
            // wrap retrieved data into a CategoryDetails object
           AdditionalNote details = new AdditionalNote();
            if (table.Rows.Count > 0)
            {
                details.Id = Int32.Parse(table.Rows[0]["Id"].ToString());
                details.BaseColor = table.Rows[0]["BaseColor"].ToString();
                details.DesignDetails = table.Rows[0]["DesignDetails"].ToString();
                details.Size = table.Rows[0]["Size"].ToString();
                details.Weight = table.Rows[0]["Weight"].ToString();
                details.Status = table.Rows[0]["Status"].ToString();
                details.Sample_Id = Int32.Parse(table.Rows[0]["Sample_Id"].ToString());


            }
            // return Note details
            return details;
        }

        // Update Sample details
        public static bool UpdateSample(string Id,string refNum,string imageUrl,DateTime datereceived, string sType,string oName,string origin,string broughtIn,
            int divId,int genderId,bool returnable,int usageId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "UpdateSample";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@RefNumber";
            param.Value = refNum;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ImageUrl";
            param.Value = imageUrl;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DateReceived";
            param.Value = datereceived;
            param.DbType = DbType.DateTime;
            param.Size = 50;
            comm.Parameters.Add(param);

           // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@SampleType";
            param.Value = sType;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@OwnersName";
            param.Value = oName;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Origin";
            param.Value = origin;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BroughtInBy";
            param.Value = broughtIn;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Division_Id";
            param.Value = divId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Gender_Id";
            param.Value = genderId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Returnable";
            param.Value = returnable;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Usage_Id";
            param.Value = usageId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool UpdateNoteDetails(string Id, string baseColor,string designDetails,string size,
            string weight,string status,string productionSchedule,string etaMarket,string color,string typeOfKnitWeave,
                bool fullSleeve,bool sleeveless,bool heavyWeight,bool mediumWeight,bool lightWeight,string additionalNotes,
                    bool embroideredEmblem,bool vNeckfront,string finishingDetails)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "UpdateNotedetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BaseColor";
            param.Value = baseColor;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DesignDetails";
            param.Value = designDetails;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Size";
            param.Value = size;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Weight";
            param.Value = weight;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = status;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductionSchedule";
            param.Value = productionSchedule;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ETAMarket";
            param.Value = etaMarket;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Color";
            param.Value = color;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@TypeOfKnitWeave";
            param.Value = typeOfKnitWeave;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FullSleeve";
            param.Value = fullSleeve;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Sleeveless";
            param.Value = sleeveless;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@HeavyWeight";
            param.Value = heavyWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@MediumWeight";
            param.Value = mediumWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@LightWeight";
            param.Value = lightWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@AdditionalNotes";
            param.Value = additionalNotes;
            param.DbType = DbType.String;
            param.Size = 600;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@VNeckFront";
            param.Value = vNeckfront;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FinishingDetails";
            param.Value = finishingDetails;
            param.DbType = DbType.String;
            param.Size = 600;
            comm.Parameters.Add(param);


            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        // Delete Sample
        public static bool DeleteSample(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "DeleteSample";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the Sample has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {

                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public static bool DeleteNoteDetails(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "DeleteNoteDetails";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the Sample has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {

                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        // Add a new Sample
        public static bool AddSample(string refNum, DateTime dRec, string sType, string oName, string origin, string broughtIn, string imageUrl,
            int divId, int genderId, bool retId, int usageId)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "AddSample";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@RefNumber";
            param.Value = refNum;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DateReceived";
            param.Value = dRec;
            param.DbType = DbType.DateTime;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@SampleType";
            param.Value = sType;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@OwnersName";
            param.Value = oName;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Origin";
            param.Value = origin;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BroughtInBy";
            param.Value = broughtIn;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ImageUrl";
            param.Value = imageUrl;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Division_Id";
            param.Value = divId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Gender_Id";
            param.Value = genderId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Returnable";
            param.Value = retId;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Usage_Id";
            param.Value = usageId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool AddNote(string baseColor, string designDetails, string size, string weight, string status, int sampleId, string prodSchedule,string ETA,string color,
          string typeOfKnit, bool fullSleeve,bool sleevless,bool heavyWeight,bool mediumWeight,bool lightWeight,string additionalNotes,bool embro,bool vNeck,string finishDetails)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "AddNote";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BaseColor";
            param.Value = baseColor;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DesignDetails";
            param.Value = designDetails;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Size";
            param.Value = size;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Weight";
            param.Value = weight;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = status;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Sample_Id";
            param.Value = sampleId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductionSchedule";
            param.Value = prodSchedule;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@ETAMarket";
            param.Value = ETA;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Color";
            param.Value = color;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@TypeOfKnitWeave";
            param.Value = typeOfKnit;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FullSleeve";
            param.Value = fullSleeve;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@Sleeveless";
            param.Value = sleevless;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@HeavyWeight";
            param.Value = heavyWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@MediumWeight";
            param.Value = mediumWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@LightWeight";
            param.Value = lightWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@AdditionalNotes";
            param.Value = additionalNotes;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@EmbroideredEmblem";
            param.Value = embro;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@VNeckFront";
            param.Value = vNeck;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param = comm.CreateParameter();
            param.ParameterName = "@FinishingDetails";
            param.Value = finishDetails;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }


        public static bool UpdateNote(string Id,string baseColor, string designDetails, string size, string weight, string status, int sampleId, string prodSchedule, string ETA, string color,
          string typeOfKnit, bool fullSleeve, bool sleevless, bool heavyWeight, bool mediumWeight, bool lightWeight, string additionalNotes, bool embro, bool vNeck, string finishDetails)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "UpdateNote";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@BaseColor";
            param.Value = baseColor;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@DesignDetails";
            param.Value = designDetails;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Size";
            param.Value = size;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Weight";
            param.Value = weight;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = status;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Sample_Id";
            param.Value = sampleId;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@ProductionSchedule";
            param.Value = prodSchedule;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param.ParameterName = "@ETAMarket";
            param.Value = ETA;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param.ParameterName = "@Color";
            param.Value = color;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param.ParameterName = "@TypeOfKnitWeave";
            param.Value = typeOfKnit;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            param.ParameterName = "@FullSleeve";
            param.Value = fullSleeve;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param.ParameterName = "@Sleeveless";
            param.Value = sleevless;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param.ParameterName = "@HeavyWeight";
            param.Value = heavyWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param.ParameterName = "@MediumWeight";
            param.Value = mediumWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param.ParameterName = "@LightWeight";
            param.Value = lightWeight;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param.ParameterName = "@AdditionalNotes";
            param.Value = additionalNotes;
            param.DbType = DbType.String;
            comm.Parameters.Add(param);

            param.ParameterName = "@EmbroideredEmblem";
            param.Value = embro;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param.ParameterName = "@VNeckFront";
            param.Value = vNeck;
            param.DbType = DbType.Boolean;
            comm.Parameters.Add(param);

            param.ParameterName = "@FinishingDetails";
            param.Value = finishDetails;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool DeleteNote(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "DeleteNote";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the Sample has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {

                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public static bool AddUsage(string usage )
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "AddUsage";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Usg";
            param.Value = usage;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);

            

            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool UpdateUsage(string Id,string usage)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "UpdateUsage";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Usg";
            param.Value = usage;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool DeleteUsage(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "DeleteUsage";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the Sample has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {

                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public static bool AddDivision(string div)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "AddDivision";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Div";
            param.Value = div;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool UpdateDivision(string Id, string div)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "UpdateDivision";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Div";
            param.Value = div;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool DeleteDivision(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "DeleteDivision";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the Sample has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {

                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public static bool AddGender(string gen)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "AddGender";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Gen";
            param.Value = gen;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool UpdateGender(string Id, string gen)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "UpdateGender";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Gen";
            param.Value = gen;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool DeleteGender(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "DeleteGender";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the Sample has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {

                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }

        public static bool AddReturnable(string status)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "AddReturnable";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = status;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool UpdateReturnable(string Id, string status)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "UpdateReturnable";
            // create a new parameter
            DbParameter param = comm.CreateParameter();

            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // create a new parameter
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = status;
            param.DbType = DbType.String;
            param.Size = 50;
            comm.Parameters.Add(param);



            // result will represent the number of changed rows
            int result = -1;
            try
            {
                // execute the stored procedure
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {
                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success 
            return (result != -1);
        }

        public static bool DeleteReturnable(string Id)
        {
            // get a configured DbCommand object
            DbCommand comm = GenericDataAccess.CreateCommand();
            // set the stored procedure name
            comm.CommandText = "DeleteReturnable";
            // create a new parameter
            DbParameter param = comm.CreateParameter();
            param.ParameterName = "@Id";
            param.Value = Id;
            param.DbType = DbType.Int32;
            comm.Parameters.Add(param);
            // execute the stored procedure; an error will be thrown by the
            // database if the Sample has related categories, in which case
            // it is not deleted
            int result = -1;
            try
            {
                result = GenericDataAccess.ExecuteNonQuery(comm);
            }
            catch
            {

                // any errors are logged in GenericDataAccess, we ignore them here
            }
            // result will be 1 in case of success
            return (result != -1);
        }
    }
}