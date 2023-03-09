using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using WebApiVS.Configuration;

namespace WebApiVS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //HomeOptions h = new ();
            //h.Address = new();
            //h.Address.Street = "dsfdsfsdf";
            //string json = SerializeJSon<HomeOptions>(h);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


        //public static string SerializeJSon<T>(T t)
        //{
        //    try
        //    {
        //        using MemoryStream stream = new();
        //        DataContractJsonSerializer ds = new(typeof(T));
        //        DataContractJsonSerializerSettings s = new();
        //        ds.WriteObject(stream, t);
        //        string jsonString = Encoding.UTF8.GetString(stream.ToArray());
        //        stream.Close();
        //        return jsonString;
        //    }
        //    catch (Exception ex)
        //    {
        //        ;
        //    }
        //    return "";
        //}

    }
}
