using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : BaseClass, IDataRepository<ApplicantEducationPoco>
    {
        public ApplicantEducationRepository(string connectionString):base(connectionString)
        {
        }

        public ApplicantEducationRepository()
        {

        }

        public void Add(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"INSERT INTO[dbo].[Applicant_Educations]
                                       ([Id]
                                       ,[Applicant]
                                       ,[Major]
                                       ,[Certificate_Diploma]
                                       ,[Start_Date]
                                       ,[Completion_Date]
                                       ,[Completion_Percent])
                                 VALUES
                                       (@Id
                                       ,@Applicant
                                       ,@Major
                                       ,@Certificate_Diploma
                                       ,@Start_Date
                                       ,@Completion_Date
                                       ,@Completion_Percent)";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
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

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = @"SELECT [Id]
                                      ,[Applicant]
                                      ,[Major]
                                      ,[Certificate_Diploma]
                                      ,[Start_Date]
                                      ,[Completion_Date]
                                      ,[Completion_Percent]
                                      ,[Time_Stamp]
                                  FROM [dbo].[Applicant_Educations]";
                int counter = 0;
                ApplicantEducationPoco[] pocos = new ApplicantEducationPoco[500];
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while(rdr.Read())
                {
                    ApplicantEducationPoco poco = new ApplicantEducationPoco();
                    poco.Id = rdr.GetGuid(0);
                    poco.Applicant = rdr.GetGuid(1);
                    poco.Major = rdr.GetString(2);
                    poco.CertificateDiploma = rdr.GetString(3);
                    poco.StartDate = rdr.GetDateTime(4);
                    poco.CompletionDate = rdr.GetDateTime(5);
                    poco.CompletionPercent = rdr.GetByte(6);
                    //poco.TimeStamp = (byte[])rdr[7];

                    pocos[counter] = poco;
                    counter++;
                }
                conn.Close();
                return pocos.Where(a => a != null ).ToList();
            }
                
        }

        public IList<ApplicantEducationPoco> GetList(Func<ApplicantEducationPoco, bool> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Func<ApplicantEducationPoco, bool> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            ApplicantEducationPoco[] pocos = GetAll().ToArray();
            return pocos.Where(where).ToList().FirstOrDefault();
          }
        

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM [dbo].[Applicant_Educations]
                                     WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            //throw new NotImplementedException();
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantEducationPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                                   SET [Id] = @Id
                                      ,[Applicant] = @Applicant
                                      ,[Major] = @Major
                                      ,[Certificate_Diploma] = @Certificate_Diploma
                                      ,[Start_Date] = @Start_Date
                                      ,[Completion_Date] = @Completion_Date
                                      ,[Completion_Percent] = @Completion_Percent
                                 WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Major", poco.Major);
                    cmd.Parameters.AddWithValue("@Certificate_Diploma", poco.CertificateDiploma);
                    cmd.Parameters.AddWithValue("@Start_Date", poco.StartDate);
                    cmd.Parameters.AddWithValue("@Completion_Date", poco.CompletionDate);
                    cmd.Parameters.AddWithValue("@Completion_Percent", poco.CompletionPercent);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }

            }
        }
    }
}
