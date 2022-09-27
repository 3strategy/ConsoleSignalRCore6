// See https://aka.ms/new-console-template for more information
//using ConsoleSignalRCore6;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System.Net.Sockets;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(GetLocalIPAddress());
        CreateWebHostBuilder(args).Build().Run();
    }

    private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .UseStartup<Startup>().UseUrls("http://+:8081"); //UseUrls make it possible to listen to outside (not just localhost)
    //this port should be routed to your machine in the router. 
    //Inbound firewall rule should be added as well.

    public static string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
}
