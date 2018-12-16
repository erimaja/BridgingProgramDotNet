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
    public class ApplicantResumeRepository : BaseClass, IDataRepository<ApplicantResumePoco>
    {
        public void Add(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                foreach(ApplicantResumePoco poco in items)
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = @"INSERT INTO [dbo].[Applicant_Resumes]
                                       ([Id]
                                       ,[Applicant]
                                       ,[Resume]
                                       ,[Last_Updated])
                                 VALUES
                                       (@Id
                                       ,@Applicant
                                       ,@Resume
                                       ,@Last_Updated)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id );
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);
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

        public IList<ApplicantResumePoco> GetAll(params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                      ,[Applicant]
                                      ,[Resume]
                                      ,[Last_Updated]
                                  FROM [dbo].[Applicant_Resumes]";
                int count = 0;
                ApplicantResumePoco[] pocos = new ApplicantResumePoco[500];
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    ApplicantResumePoco poco = new ApplicantResumePoco();
                    poco.Id = rdr.GetGuid(0);
                    poco.Applicant = rdr.GetGuid(1);
                    poco.Resume = rdr.GetString(2);
                    if (!rdr.IsDBNull(3))
                    {
                        poco.LastUpdated = rdr.GetDateTime(3);
                    }
                    pocos[count] = poco;
                    count++;
                }
                conn.Close();
                return pocos.Where(a => a != null).ToList();
            }
        }

        public IList<ApplicantResumePoco> GetList(Func<ApplicantResumePoco, bool> where, params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Func<ApplicantResumePoco, bool> where, params System.Linq.Expressions.Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Resumes]
                                     WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Resumes]
                                       SET [Id] = @Id
                                          ,[Applicant] = @Applicant
                                          ,[Resume] = @Resume
                                          ,[Last_Updated] = @Last_Updated
                                 WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }
    }
}
