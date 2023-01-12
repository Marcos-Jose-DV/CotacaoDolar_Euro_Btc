
using DollarContacao.models;
using Newtonsoft.Json;
namespace DollarContacao;

public class Porgram
{
    static async Task Main(string[] args)
    {
        var url = "https://economia.awesomeapi.com.br/last/";
        using HttpClient client = new() { BaseAddress = new Uri(url) };

        var response = await client.GetAsync("/USD-BRL");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var cotacaos = JsonConvert.DeserializeObject<Cotacao[]>(content);
            foreach (var cotacao in cotacaos)
            {
                Console.WriteLine($"Name: {cotacao.Name} - {cotacao.Code}");
                Console.WriteLine($"Máximo: {cotacao.High}");
                Console.WriteLine($"Mínimo: {cotacao.Low}");
                Console.WriteLine();
            }

            response = await client.GetAsync("/EUR-BRL");
            content = await response.Content.ReadAsStringAsync();
            cotacaos = JsonConvert.DeserializeObject<Cotacao[]>(content);
            foreach (var cotacao in cotacaos)
            {
                Console.WriteLine($"Name: {cotacao.Name} - {cotacao.Code}");
                Console.WriteLine($"Máximo: {cotacao.High}");
                Console.WriteLine($"Mínimo: {cotacao.Low}");
                Console.WriteLine();
            }

            response = await client.GetAsync("/BTC-BRL");
            content = await response.Content.ReadAsStringAsync();
            cotacaos = JsonConvert.DeserializeObject<Cotacao[]>(content);
            foreach (var cotacao in cotacaos)
            {
                Console.WriteLine($"Name: {cotacao.Name} - {cotacao.Code}");
                Console.WriteLine($"Máximo: {cotacao.High}");
                Console.WriteLine($"Mínimo: {cotacao.Low}");
            }
        }
        else
        {
            Console.WriteLine("Error, Get falhou");
        }
    }
}
