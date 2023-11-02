namespace Core_CQRS_Mediatr.Models
{
    public class ResponseBase
    {
        public string? Message { get; set; }
        public int StatusCode { get; set; }
        public bool IsSuccess { get; set; } = false;
    }
}
