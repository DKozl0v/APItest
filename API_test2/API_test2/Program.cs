

using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace API_test2
{
    class Program
    {
        static void Main(string[] args)
        {
            string URL = "https://reqres.in/api/users/1";
            var request = (HttpWebRequest)WebRequest.Create(URL);
            
            request.Method = "GET";
            request.Proxy.Credentials = new NetworkCredential("student", "student");
            var response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string Text = reader.ReadToEnd();
            var JsonText = JsonConvert.DeserializeObject<User>(Text);
            Console.WriteLine($"{JsonText.data.id} {JsonText.data.last_name} {JsonText.data.first_name} {JsonText.data.email}");
            Console.ReadLine();
        }

    }
}
