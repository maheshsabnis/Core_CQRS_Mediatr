using Core_CQRS_Mediatr.Models;

namespace Core_CQRS_Mediatr.Services
{
    public interface IDataAccessService<TEntity, in TPk> where TEntity : class
    {
        Task<ResponseObject<TEntity>> GetAsync();
        Task<ResponseObject<TEntity>> GetByIdAsync(TPk id);
        Task<ResponseObject<TEntity>> CreateAsync(TEntity entity);
        Task<ResponseObject<TEntity>> UpdateAsync(TPk id,TEntity entity);
        Task<ResponseObject<TEntity>> DeleteAsync(TPk id);
    }
}
