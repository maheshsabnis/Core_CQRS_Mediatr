namespace Core_CQRS_Mediatr.Models
{
    public class ResponseRecords<TEntity> : ResponseBase where TEntity : class
    {
        public IEnumerable<TEntity>? Records { get; set; }
    }
}
