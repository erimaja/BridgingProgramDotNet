using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class SecurityRoleRepository : BaseClass, IDataRepository<SecurityRolePoco>
    {
        public void Add(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach(SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Security_Roles]
                                           ([Id]
                                           ,[Role]
                                           ,[Is_Inactive])
                                     VALUES
                                           (@Id
                                           ,@Role
                                           ,@Is_Inactive)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<SecurityRolePoco> GetAll(params System.Linq.Expressions.Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                      ,[Role]
                                      ,[Is_Inactive]
                                  FROM [dbo].[Security_Roles]";
                int count = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                SecurityRolePoco[] pocos = new SecurityRolePoco[500];
                while (rdr.Read())
                {
                    SecurityRolePoco poco = new SecurityRolePoco();
                    poco.Id = rdr.GetGuid(0);
                    poco.Role = rdr.GetString(1);
                    poco.IsInactive = rdr.GetBoolean(2);
                    pocos[count] = poco;
                    count++;
                }
                conn.Close();
                return pocos.Where(a => a != null).ToList();
            }
        }

        public IList<SecurityRolePoco> GetList(Func<SecurityRolePoco, bool> where, params System.Linq.Expressions.Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public SecurityRolePoco GetSingle(Func<SecurityRolePoco, bool> where, params System.Linq.Expressions.Expression<Func<SecurityRolePoco, object>>[] navigationProperties)
        {
            SecurityRolePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Security_Roles]
                                     WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params SecurityRolePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SecurityRolePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Security_Roles]
                                       SET [Id] = @Id
                                          ,[Role] = @Role
                                          ,[Is_Inactive] = @Is_Inactive
                                 WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Role", poco.Role);
                    cmd.Parameters.AddWithValue("@Is_Inactive", poco.IsInactive);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
