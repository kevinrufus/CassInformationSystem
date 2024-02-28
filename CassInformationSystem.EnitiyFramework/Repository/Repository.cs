using CassInformationSystem.EnitiyFramework.DBContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CassInformationSystem.EnitiyFramework.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly CassDbContext _context;

        public Repository(CassDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> expression) =>
            await _context.Set<TEntity>().Where(expression).ToListAsync();
        public async Task Add(TEntity entity)
        {
            _ = await _context.Set<TEntity>().AddAsync(entity);
            _ = await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _ = _context.Set<TEntity>().Remove(entity);
            _ = _context.SaveChanges();
        }

        public async Task<TEntity?> Get(long id) => await _context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAll() => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public void Update(TEntity entityToUpdate, TEntity entity)
        {
            _ = _context.Set<TEntity>().Update(entity);
            _ = _context.SaveChanges();
        }

        public async Task<IEnumerable<TEntity>> ExecuteStoredProc(int shipperId)
        {
            var parameterTop = new SqlParameter
            {
                ParameterName = "shipper_id",
                SqlDbType = System.Data.SqlDbType.Int,
                Value = shipperId,
            };
            return await _context.Set<TEntity>().FromSqlRaw("EXEC Shipper_Shipment_Details @shipper_id",
                parameterTop).AsNoTracking().ToListAsync();
        }
    }
}
