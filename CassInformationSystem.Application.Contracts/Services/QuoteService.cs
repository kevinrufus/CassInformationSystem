using CassInformationSystem.Application.Contracts;
using CassInformationSystem.Application.DTOs;
using System.Net.Http.Json;

namespace CassInformationSystem.Application.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly HttpClient _httpClient;

        public QuoteService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.quotable.io/random");
        }

        public async Task<Dictionary<string, List<QuoteTransferableDto>>?> GetQuotesList(string authorName, int count)
        {
            var quotes = await _httpClient.GetFromJsonAsync<List<QuoteTransferableDto>>($"quotes/random?author={authorName}&limit={count}");
            var quotesLenght = quotes?.ToDictionary(qoute => qoute.Content!, qoute => qoute?.Content?.Split().Length);
            return quotes?.GroupBy(quote => quotesLenght?[quote.Content!] < 11 ? "Short" : quotesLenght?[quote.Content!] > 20 ? "Long" : "Medium")
                                  .ToDictionary(group => group.Key, group => group.ToList());
        }

        public async Task<QuoteTransferableDto?> GetRandomQuote()
        {
            return await _httpClient.GetFromJsonAsync<QuoteTransferableDto>("random");
        }
    }
}
