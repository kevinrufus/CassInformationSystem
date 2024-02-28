namespace CassInformationSystem.Application.DTOs
{
    public class QuoteTransferableDto
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