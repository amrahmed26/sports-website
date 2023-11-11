using Dapper;
using System.Data;
using System.Data.SqlClient;


namespace Sports.Infastructure.DapperORM
{
    public class DapperORM
    {
        public static string ConnectionString { get; set; } = "";
        private IDbConnection Db { get; set; }
        private IDbTransaction Transaction {get; set; }
        private static readonly Lazy<DapperORM> dapper = new Lazy<DapperORM>(() => new DapperORM());
        public static DapperORM dapperInstance => dapper.Value;


        private DapperORM()
        {
            Db = new SqlConnection(ConnectionString);

        }
     
        public async Task<List<T>> GetDataAsync<T>(string Query) where T : class
        {
            var Result = await Db.QueryAsync<T>(Query, commandTimeout: 100000);
            return Result.ToList();
        }   
        public List<T> GetData<T>(string Query) where T : class
        {
            var Result =  Db.Query<T>(Query, commandTimeout: 100000);
            return Result.ToList();
        }
        public async Task<bool> RunDML(string Query)
        {
            try
            {
               await  Db.ExecuteAsync(Query);
                return true;
            }
            catch (Exception )
            {

                return false ;
            }

        }

        public async Task<int> GetCount(string Query)
        {
            var Result = await Db.ExecuteScalarAsync(Query);
            return (int)Result;
        }
        public void BeginTransaction()
        {
            if (Transaction == null)
            {
                Transaction = Db.BeginTransaction();
            }
        }

        public void CommitTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction = null; 
            }
        }

        public void RollbackTransaction()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction = null; 
            }
        }
        public void Dispose()
        {
            if (Transaction != null)
            {
                Transaction.Dispose();
                Transaction = null;
            }

            if (Db.State != ConnectionState.Closed)
            {
                Db.Close();
            }

            Db.Dispose();
        }
    }

}
