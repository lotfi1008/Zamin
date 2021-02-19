using Zamin.Infra.Data.Sql.Commands;
using Zamin.Utilities;

namespace Sample.Infra.Data.Sql.Command.Common
{
    public class SampleUnitOfWork : BaseEntityFrameworkUnitOfWork<SampleCommandDbContext>
    {
        public SampleUnitOfWork(SampleCommandDbContext dbContext, ZaminServices zaminApplicationContext) : base(dbContext, zaminApplicationContext)
        {
        }
    }
}
