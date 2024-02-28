using AutoMapper;
using CassInformationSystem.Application.Contracts;
using CassInformationSystemApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace CassInformationSystemApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuotesController : ControllerBase
    {
        private readonly ILogger<QuotesController> _logger;
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public QuotesController(ILogger<QuotesController> logger, IQuoteService quoteService, IMapper mapper)
        {
            _logger = logger;
            _quoteService = quoteService;
            _mapper = mapper;
        }

        [HttpGet("get-random-quote", Name = "GetRandomQuote")]
        public async Task<ActionResult> GetRandomQuote()
        {
            _logger.LogInformation("Get Random Quote - QuoteController function called");
            var randomQuote = await _quoteService.GetRandomQuote();
            _logger.LogInformation("Get Random Quote - QuoteController function executed");
            return Ok(new ResponseModel(randomQuote, (int)HttpStatusCode.OK, true));
        }

        [HttpGet("get-quotes-list", Name = "GetQuotesList")]
        public async Task<ActionResult> GetQuotesList([Required] string authorName,[Required] int count)
        {
            _logger.LogInformation("Get Quotes List - QuoteController function called");
            var quotes = await _quoteService.GetQuotesList(authorName, count);
            if(quotes?.Count > 0)
            {
                QuotesListReturnableDto quotesListReturnable = new()
                {
                    ShortLengthQuotes = _mapper.Map<List<Quotes>>(quotes?.GetValueOrDefault("Short")),
                    MediumLengthQuotes = _mapper.Map<List<Quotes>>(quotes?.GetValueOrDefault("Medium")),
                    LongLengthQuotes = _mapper.Map<List<Quotes>>(quotes?.GetValueOrDefault("Long"))
                };
                _logger.LogInformation("Get Random Quote - QuoteController function executed");
                return Ok(new ResponseModel(quotesListReturnable, (int)HttpStatusCode.OK, true));
            }
            else
            {
                _logger.LogInformation("Get Random Quote - QuoteController function executed but no quotes found for author @authorName", authorName);
                return Ok(new ResponseModel(Array.Empty<Quotes>(), (int)HttpStatusCode.NotFound,
                    true, "No quotes found"));
            }
        }
    }
}
