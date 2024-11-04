using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

public class Program
{

    private static readonly string baseUrl = "https://jsonmock.hackerrank.com/api/football_matches";
    private static readonly HttpClient client = new HttpClient();
    public static void Main()
    {
        string teamName = "Paris Saint-Germain";
        int year = 2013;
        int totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team "+ teamName +" scored "+ totalGoals.ToString() + " goals in "+ year);

        teamName = "Chelsea";
        year = 2014;
        totalGoals = getTotalScoredGoals(teamName, year);

        Console.WriteLine("Team " + teamName + " scored " + totalGoals.ToString() + " goals in " + year);

        // Output expected:
        // Team Paris Saint - Germain scored 109 goals in 2013
        // Team Chelsea scored 92 goals in 2014
    }

    public static  int getTotalScoredGoals(string team, int year)
    {

        int totalGoals = 0;
        int team1Or2 = 1;

        while (team1Or2 <= 2) // O loop que define time da casa e visitante
        {            
            int page = 1;
            bool hasMorePages;

            do
            {
                // Construir URL para a página atual, considerando "Casa" e "Visitante"
                string url = $"{baseUrl}?year={year}&team{team1Or2}={Uri.EscapeDataString(team)}&page={page}";

                // Fazer a requisição HTTP
                HttpResponseMessage response = client.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                // Ler e processar a resposta
                string responseBody = response.Content.ReadAsStringAsync().Result;
                JObject json = JObject.Parse(responseBody);

                // Obter a lista de partidas e o total de páginas
                var matches = json["data"];
                int totalPages = (int)json["total_pages"];
                hasMorePages = page < totalPages;

                // Somar os gols do time especificado em cada partida como "Casa" e "Visitante"
                foreach (var match in matches)
                {
                    totalGoals += int.Parse((string)match["team"+team1Or2+"goals"]);
                }

                page++;
            } while (hasMorePages);
            team1Or2++;
        }


        return totalGoals;
    }

}