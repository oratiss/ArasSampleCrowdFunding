using Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Users;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.Repository.Mssql.DataContexts;
using Aras.SampleCrowdFunding.Repository.Mssql.Repositories.Users;

namespace Aras.SampleCrowdFunding.Repository.Mssql.UnitOfWorks
{
    public class CrowdFundingUnitOfWork(CrowdFundingDataContext dataContext) : ICrowdFundingUnitOfWork
    {
        private bool _disposed = false;
        public bool IsDisposed => _disposed;

        #region repositories

        private IWritableUserRepository? _writableUserRepository;
        public IWritableUserRepository WritableUserRepository
        {
            get => _writableUserRepository ??= new WritableUserRepository(dataContext);
            set => throw new NotImplementedException();
        }

        #endregion

        public async Task BeginTransactionAsync()
        {
            await dataContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await dataContext.Database.CommitTransactionAsync();
        }

        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await dataContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
