using CassInformationSystem.Application.DTOs;

namespace CassInformationSystem.Application.Contracts
{
    public interface IQuoteService
    {
        Task<QuoteTransferableDto?> GetRandomQuote();
        Task<Dictionary<string, List<QuoteTransferableDto>>?> GetQuotesList(string authorName, int count);
    }
}
