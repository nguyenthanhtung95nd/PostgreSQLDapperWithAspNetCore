using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using PostgreSQLDapperWithAspNetCore.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PostgreSQLDapperWithAspNetCore.Repository
{
    public class ProvinceRepository : IRepository<Province>
    {
        private string connectionString;

        public ProvinceRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetValue<string>("DBInfo:ConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new NpgsqlConnection(connectionString);
            }
        }

        public void Add(Province item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("INSERT INTO Province (code,name,short_name,slug,seq_order) VALUES(@Code,@Name,@ShortName,@Slug,@SeqOrder)", item);
            }
        }

        public IEnumerable<Province> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Province>("SELECT * FROM Province");
            }
        }

        public Province FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Province>("SELECT * FROM Province WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void Remove(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Execute("DELETE FROM Province WHERE Id=@Id", new { Id = id });
            }
        }

        public void Update(Province item)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                dbConnection.Query("UPDATE Province SET Name = @Name,  Code  = @Code, ShortName= @ShortName, Slug= @Slug, SeqOrder = @SeqOrder WHERE id = @Id", item);
            }
        }
    }
}