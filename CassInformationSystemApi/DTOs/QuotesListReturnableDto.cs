namespace CassInformationSystemApi.DTOs
{
    public class QuotesListReturnableDto
    {
        public List<Quotes>? ShortLengthQuotes { get; set; }
        public List<Quotes>? MediumLengthQuotes { get; set; }
        public List<Quotes>? LongLengthQuotes { get; set; }
    }

    public class Quotes
    {
        public string? _Id { get; set; }
        public string? Content { get; set; }
        public string? Author { get; set; }
        public string? AuthorSlug { get; set; }
        public long Length { get; set; }
        public string? DateAdded { get; set; }
        public string? DateModified { get; set; }
    }
}
