using Aras.SampleCrowdFunding.Application.Repositories.IWritableRepositories.Categories;
using Aras.SampleCrowdFunding.Application.UnitOFWorks;
using Aras.SampleCrowdFunding.Repository.Mssql.DataContexts;
using Aras.SampleCrowdFunding.Repository.Mssql.Repositories.Prize;

namespace Aras.SampleCrowdFunding.Repository.Mssql.UnitOfWorks
{
    public class CustomerClubUnitOfWork : ICustomerClubUnitOfWork
    {
        private readonly CustomerClubDataContext _dataContext;
        private bool _disposed = false;

        public CustomerClubUnitOfWork(CustomerClubDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool IsDisposed => _disposed;

        #region repositories

        private IWritableCategoryRepository? _writableCategoryRepository;
        public IWritableCategoryRepository WritableCategoryRepository => _writableCategoryRepository ??= new WritableCategoryRepository(_dataContext);



        #endregion

        public async Task BeginTransactionAsync()
        {
            await _dataContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _dataContext.Database.CommitTransactionAsync();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dataContext.Dispose();
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
