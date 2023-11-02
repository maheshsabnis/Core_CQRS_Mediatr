using Core_CQRS_Mediatr.Models;

namespace Core_CQRS_Mediatr.Services
{
    public interface IDataAccessService<TEntity, in TPk> where TEntity : class
    {
        Task<ResponseRecords<TEntity>> GetAsync();
        Task<ResponseRecord<TEntity>> GetByIdAsync(TPk id);
        Task<ResponseRecord<TEntity>> CreateAsync(TEntity entity);
        Task<ResponseRecord<TEntity>> UpdateAsync(TPk id,TEntity entity);
        Task<ResponseRecord<TEntity>> DeleteAsync(TPk id);
    }
}
