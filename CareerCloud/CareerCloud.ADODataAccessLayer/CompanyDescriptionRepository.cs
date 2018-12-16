using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class CompanyDescriptionRepository : BaseClass, IDataRepository<CompanyDescriptionPoco>
    {
        public void Add(params CompanyDescriptionPoco[] items)
        {
            using(SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO [dbo].[Company_Descriptions]
                                       ([Id]
                                       ,[Company]
                                       ,[LanguageID]
                                       ,[Company_Name]
                                       ,[Company_Description])
                                 VALUES
                                       (@Id
                                       ,@Company
                                       ,@LanguageID
                                       ,@Company_Name
                                       ,@Company_Description)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id );
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
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

        public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                      ,[Company]
                                      ,[LanguageID]
                                      ,[Company_Name]
                                      ,[Company_Description]
                                      ,[Time_Stamp]
                                  FROM [dbo].[Company_Descriptions]";
                int count = 0;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[800];
                while (rdr.Read())
                {
                    CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
                    poco.Id = rdr.GetGuid(0);
                    poco.Company = rdr.GetGuid(1);
                    poco.LanguageId = rdr.GetString(2);
                    poco.CompanyName = rdr.GetString(3);
                    poco.CompanyDescription = rdr.GetString(4);
                    //poco.TimeStamp;
                    pocos[count] = poco;
                    count++;
                }
                conn.Close();
                return pocos.Where(a => a != null).ToList();
            }
        }

        public IList<CompanyDescriptionPoco> GetList(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public CompanyDescriptionPoco GetSingle(Func<CompanyDescriptionPoco, bool> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
        {
            CompanyDescriptionPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Company_Descriptions]
                                     WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params CompanyDescriptionPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (CompanyDescriptionPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Company_Descriptions]
                                       SET [Id] = @Id
                                          ,[Company] = @Company
                                          ,[LanguageID] = @LanguageID
                                          ,[Company_Name] = @Company_Name
                                          ,[Company_Description] = @Company_Description
                                 WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Company", poco.Company);
                    cmd.Parameters.AddWithValue("@LanguageID", poco.LanguageId);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Company_Description", poco.CompanyDescription);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
