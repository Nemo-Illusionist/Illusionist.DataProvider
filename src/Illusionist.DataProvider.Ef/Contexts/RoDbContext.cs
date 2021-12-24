using System.Threading;
using System.Threading.Tasks;
using Illusionist.DataProvider.Ef.Contracts;
using Illusionist.DataProvider.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Illusionist.DataProvider.Ef.Contexts
{
    public abstract class RoDbContext : ModelDbContext
    {
        protected RoDbContext(IModelStore modelStore) 
            : base(modelStore)
        {
        }

        protected RoDbContext(IModelStore modelStore, DbContextOptions options) 
            : base(modelStore, options)
        {
        }

        public override int SaveChanges()
        {
            throw new AccessModifyException();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            throw new AccessModifyException();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return Task.FromException<int>(new AccessModifyException());
        }

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            return Task.FromException<int>(new AccessModifyException());
        }
    }
}