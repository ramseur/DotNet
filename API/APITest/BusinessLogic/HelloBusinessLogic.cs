using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Configuration;
 
 

namespace BusinessLogic
{
   public class HelloBusinessLogic
   {

      public static string GetHello()
         {
         var result = String.Empty;
         var APILocation = ConfigurationManager.AppSettings["APILocation"];
         var method = "/hello";

         //if the config is not set up use the fall back
         if (String.IsNullOrEmpty(APILocation))
            APILocation = "http://localhost:51634/api";

         try
         {
            using (var client = new WebClient()) //WebClient  
            {
               client.Headers.Add("Content-Type:application/json"); //Content-Type  
               client.Headers.Add("Accept:application/json");
               result = client.DownloadString(APILocation + method); //URI  

            }
         }
         catch (Exception ex)
         {
            // handle exception in log file
            // most likely the API is down or cant be found
         }

         if (String.IsNullOrEmpty(result))
         {

            return "Api Call Failed";
         }

         else
         { return result; }

         }


      /// <summary>
      /// Allows you to Write Hello World to any place such as DB
      /// </summary>
      /// <returns></returns>
      public static void WriteHello()
      {
         var WriteLocation = ConfigurationManager.AppSettings["WriteLocation"];
         // Get Hello from API
         var hello = GetHello();

         if (String.Compare("screen", WriteLocation, true) == 0)
            Console.WriteLine(hello);

         else
         {
            // use a different key to write somewhere else such as a db or a file location
            // however for now ive simply provided the else
         }
      }
    }
}
