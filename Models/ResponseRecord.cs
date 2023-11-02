namespace Core_CQRS_Mediatr.Models
{
    public class ResponseRecord<TEntity>: ResponseBase where TEntity : class
    {
       public TEntity? Record { get; set; }
    }
}
