using System.Linq.Expressions;
using System.Threading.Tasks;

namespace efApp.Repository.Interfaces
{
    public interface IReadOnlyRepository<TEntity> where TEntity : class
    {
        Task<TEntity?> FindByIdAsync(int id);
        Task<List<TEntity>> GetAllAsync();
    }
}