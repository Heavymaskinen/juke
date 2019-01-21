using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using JukeApiModel;

namespace CliClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Control Juke here!");
            var client = new ApiClient("https://localhost:5001/api/");
            var input = Console.ReadLine();
            var token = LoginToken.Empty;
            while (input != "exit")
            {
                var parts = input.Split(' ');
                if (parts.Length < 1)
                {
                    continue;
                }

                var command = parts[0];
                try {
                    token = ProcessCommand(client, token, parts, command);
                } catch (Exception e) {
                    Console.WriteLine("Error: " + e.Message);
                }

                input = Console.ReadLine();

            }

        }

        private static LoginToken ProcessCommand(ApiClient client, LoginToken token, string[] parts, string command)
        {
            switch (command)
            {
                case "login":
                    string userName = parts.Length > 1 ? parts[1] : "undefined";
                    string password = parts.Length > 2 ? parts[2] : "undefined";

                    token = client.Login(userName, password);
                    if (token.Id < 0)
                    {
                        Console.WriteLine("Login failed.");
                    } else {
                        Console.WriteLine("Hello " + userName);
                    }
                    break;
                case "list":
                    if (token.Id < 0)
                    {
                        Console.WriteLine("Login first!");
                    }
                    else
                    {
                        var list = client.GetSongList(token);
                        Console.WriteLine("Available songs:");
                        foreach (var song in list)
                        {
                            Console.WriteLine(song.Artist + " - " + song.Title);
                        }
                    }
                    break;
                case "logout":
                    if (token.Id < 0)
                    {
                        Console.WriteLine("Login first!");
                    }
                    else
                    {
                        var result = client.Logout(token);
                        Console.WriteLine(result);
                        token = LoginToken.Empty;
                    }
                    break;
                case "users":
                    var users = client.GetUsers();
                    Console.WriteLine("Currently active: "+users.Count);
                    foreach (var user in users)
                    {
                        Console.WriteLine(user.Id+":"+user.UserName);
                    }
                    break;
                default:
                    Console.WriteLine("Unknown command " + command);
                    break;
            }

            return token;
        }
    }
}
