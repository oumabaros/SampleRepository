using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SamplesRepository.UserCode
{
    public class Link
    {
        // Builds an absolute URL
        private static string BuildAbsolute(string relativeUri)
        {
            // get current uri
            Uri uri = HttpContext.Current.Request.Url;
            // build absolute path
            string app = HttpContext.Current.Request.ApplicationPath;
            if (!app.EndsWith("/")) app += "/";
            relativeUri = relativeUri.TrimStart('/');
            // return the absolute path
            return HttpUtility.UrlPathEncode(
              String.Format("http://{0}:{1}{2}{3}",
              uri.Host, uri.Port, app, relativeUri));
        }

        // Generate a department URL
        public static string ToDivision(string Id, string page)
        {
            if (page == "1")
                return BuildAbsolute(String.Format("Sample.aspx?Id={0}", Id));
            else
                return BuildAbsolute(String.Format("Sample.aspx?Id={0}&Page={1}", Id, page));
        }

        // Generate a department URL for the first page
        public static string ToDivision(string Id)
        {
            return ToDivision(Id, "1");
        }

               
        public static string ToSamples(string Id)
        {
            return BuildAbsolute(String.Format("Sample.aspx?Id={0}", Id ));
        }


        public static string ToSampleDetails(string Id)
        {
            return BuildAbsolute(String.Format("SampleDetails.aspx?Id={0}", Id ));
        }

        public static string ToImageDetail(string Id)
        {
            return BuildAbsolute(String.Format("SampleImage.aspx?Id={0}", Id));
        }

        public static string ToProductImage(string fileName)
        {
            // build sample URL
            return BuildAbsolute("/SampleImgs/" + fileName);
        }
    }
}