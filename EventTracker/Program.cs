using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.RegularExpressions;

namespace EventTracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Loading pages..");
            var sites = new List<string>();
            using (WebClient client = new WebClient())
            {
                sites.Add(client.DownloadString("http://www.nintendo.dk/nyheder"));
                sites.Add(client.DownloadString("http://www.nintendo.dk/pokemon"));
                sites.Add(client.DownloadString("http://www.nintendo.no/nyheter"));
                sites.Add(client.DownloadString("http://www.nintendo.no/pokemon"));
                sites.Add(client.DownloadString("http://www.nintendo.se/nyheter"));
                sites.Add(client.DownloadString("http://www.nintendo.se/pokemon"));
                sites.Add(client.DownloadString("http://www.nintendo.fi/uutiset"));
                sites.Add(client.DownloadString("http://www.nintendo.fi/pokemon"));
            }
            Console.Write(" Pages are loaded!\n");
            Console.WriteLine("");
            Console.WriteLine("Enter Pokémon name below search for specific events.");
            Console.WriteLine("Write \"exit\" to exit the program.");
            Console.WriteLine("");
            Console.Write("Pokémon: ");
            bool close = false;
            while (!close)
            {
                string pokemon = Console.ReadLine().ToLower();
                if (pokemon == "exit") close = true;

                string dkReg = "/nyheder/[a-z0-9/-]+pokemon[a-z0-9/-]+" + pokemon + "[a-z0-9/-]*";
                string noReg = "/nyheter/[a-z0-9/-]+pokemon[a-z0-9/-]+" + pokemon + "[a-z0-9/-]*";
                string seReg = "/nyheter/[a-z0-9/-]+pokemon[a-z0-9/-]+" + pokemon + "[a-z0-9/-]*";
                string fiReg = "/uutiset/[a-z0-9/-]+pokemon[a-z0-9/-]+" + pokemon + "[a-z0-9/-]*";
                Regex dkRegex = new Regex(dkReg);
                Regex noRegex = new Regex(noReg);
                Regex seRegex = new Regex(seReg);
                Regex fiRegex = new Regex(fiReg);

                var list = new List<string>();
                foreach (Match match in dkRegex.Matches(sites[0]))
                {
                    string s = "http://www.nintendo.dk" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                foreach (Match match in dkRegex.Matches(sites[1]))
                {
                    string s = "http://www.nintendo.dk" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                foreach (Match match in noRegex.Matches(sites[2]))
                {
                    string s = "http://www.nintendo.no" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                foreach (Match match in noRegex.Matches(sites[3]))
                {
                    string s = "http://www.nintendo.no" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                foreach (Match match in seRegex.Matches(sites[4]))
                {
                    string s = "http://www.nintendo.se" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                foreach (Match match in seRegex.Matches(sites[5]))
                {
                    string s = "http://www.nintendo.se" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                foreach (Match match in fiRegex.Matches(sites[6]))
                {
                    string s = "http://www.nintendo.fi" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                foreach (Match match in fiRegex.Matches(sites[7]))
                {
                    string s = "http://www.nintendo.fi" + match.Value;
                    if (!list.Contains(s))
                    {
                        list.Add(s);
                    }
                }
                if (!list.Any())
                {
                    Console.WriteLine("No results found.");
                }
                else
                {
                    foreach (var s in list)
                    {
                        Console.WriteLine(s);
                    }
                }
                Console.WriteLine("");
                Console.Write("Pokémon: ");
            }
        }
    }
}
