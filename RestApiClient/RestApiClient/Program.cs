using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace RestApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string apiKey = "RGAPI-bc783c75-99ef-41ba-ad7e-b05cada773f9";
                Uri uri = new Uri("https://euw1.api.riotgames.com/lol/static-data/v3/champions?locale=en_US&dataById=false" + "&api_key=" + apiKey);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream());
                string content = streamReader.ReadToEnd();
                ChampionListDto champions = JsonConvert.DeserializeObject<ChampionListDto>(content);

                streamReader.Close();
                response.Close();

                using (StreamWriter streamWriter = new StreamWriter("champions.txt"))
                {
                    string fileTitle = string.Format("All League of Legends Champions Names ({0}):\n", DateTime.Now.ToString("d/M/yyy, HH:mm"));
                    streamWriter.WriteLine(fileTitle);
                    Console.WriteLine(fileTitle);
                    int count = 0;
                    foreach (var champ in champions.data)
                    {
                        count++;
                        string line = count + ". " + champ.Key + ", " + champ.Value.title;
                        streamWriter.WriteLine(line);
                        Console.WriteLine(line);
                    }
                }

            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }

            Console.ReadLine();
        }

        class ChampionListDto
        {
            public Dictionary<string, ChampionDto> data { get; set; }
            public string type { get; set; }
            public string version { get; set; }
        }
        class ChampionDto
        {
            public long id { get; set; }
            public string key { get; set; }
            public string name { get; set; }
            public string title { get; set; }
        }
    }
}
