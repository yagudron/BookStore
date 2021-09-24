using System;
using System.Linq;
using System.Threading.Tasks;
using BookStore.DataAccess.Interfaces;

namespace BookStore.DataAccess.Repositories
{

    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        protected readonly BookStoreContext RepositoryPatternDemoContext;

        public RepositoryBase(BookStoreContext repositoryPatternDemoContext)
        {
            RepositoryPatternDemoContext = repositoryPatternDemoContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return RepositoryPatternDemoContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public TEntity Add(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                RepositoryPatternDemoContext.Add(entity);
                RepositoryPatternDemoContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be saved: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                await RepositoryPatternDemoContext.AddAsync(entity);
                await RepositoryPatternDemoContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be saved: {ex.Message}", ex);
            }
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                RepositoryPatternDemoContext.Update(entity);
                RepositoryPatternDemoContext.SaveChanges();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be updated: {ex.Message}", ex);
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(AddAsync)} entity must not be null");

            try
            {
                RepositoryPatternDemoContext.Update(entity);
                await RepositoryPatternDemoContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be updated: {ex.Message}", ex);
            }
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(Remove)} entity must not be null");

            try
            {
                RepositoryPatternDemoContext.Remove(entity);
                RepositoryPatternDemoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be updated: {ex.Message}", ex);
            }
        }

        public async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
                throw new ApplicationException($"{nameof(RemoveAsync)} entity must not be null");

            try
            {
                RepositoryPatternDemoContext.Remove(entity);
                await RepositoryPatternDemoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"{nameof(entity)} could not be updated: {ex.Message}", ex);
            }
        }
    }
}
