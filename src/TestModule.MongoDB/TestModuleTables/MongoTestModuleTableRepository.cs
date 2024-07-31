using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using TestModule.MongoDB;
using Volo.Abp.Domain.Repositories.MongoDB;
using Volo.Abp.MongoDB;
using MongoDB.Driver.Linq;
using MongoDB.Driver;

namespace TestModule.TestModuleTables
{
    public abstract class MongoTestModuleTableRepositoryBase : MongoDbRepository<TestModuleMongoDbContext, TestModuleTable, Guid>
    {
        public MongoTestModuleTableRepositoryBase(IMongoDbContextProvider<TestModuleMongoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public virtual async Task DeleteAllAsync(
            string? filterText = null,
                        string? code = null,
            string? name = null,
            string? notes = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, code, name, notes);

            var ids = query.Select(x => x.Id);
            await DeleteManyAsync(ids, cancellationToken: GetCancellationToken(cancellationToken));
        }

        public virtual async Task<List<TestModuleTable>> GetListAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? notes = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, code, name, notes);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? TestModuleTableConsts.GetDefaultSorting(false) : sorting);
            return await query.As<IMongoQueryable<TestModuleTable>>()
                .PageBy<TestModuleTable, IMongoQueryable<TestModuleTable>>(skipCount, maxResultCount)
                .ToListAsync(GetCancellationToken(cancellationToken));
        }

        public virtual async Task<long> GetCountAsync(
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? notes = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetMongoQueryableAsync(cancellationToken)), filterText, code, name, notes);
            return await query.As<IMongoQueryable<TestModuleTable>>().LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<TestModuleTable> ApplyFilter(
            IQueryable<TestModuleTable> query,
            string? filterText = null,
            string? code = null,
            string? name = null,
            string? notes = null)
        {
            return query
                .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Code!.Contains(filterText!) || e.Name!.Contains(filterText!) || e.Notes!.Contains(filterText!))
                    .WhereIf(!string.IsNullOrWhiteSpace(code), e => e.Code.Contains(code))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(notes), e => e.Notes.Contains(notes));
        }
    }
}