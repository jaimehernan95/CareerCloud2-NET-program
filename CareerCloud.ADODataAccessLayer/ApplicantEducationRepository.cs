using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantEducationRepository : IDataRepository<ApplicantEducationPoco>
    {
        private readonly string _connStr;
        SqlConnection _sqlcon;

        public ApplicantEducationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            _sqlcon = new SqlConnection(_connStr);
        }

        public void Add(params ApplicantEducationPoco[] items)
        {

            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (ApplicantEducationPoco item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"INSERT INTO[dbo].[Applicant_Educations]
                                   ([Id]
                                   ,[Applicant]
                                   ,[Major]
                                   ,[Certificate_Diploma]
                                   ,[Start_Date]
                                   ,[Completion_Date]
                                   ,[Completion_Percent])
                             VALUES
                                 (
                                    @Id
                                   ,@Applicant
                                   ,@Major
                                   ,@Certificate_Diploma
                                   ,@Start_Date
                                   ,@Completion_Date
                                   ,@Completion_Percent 
                                  )";
                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Applicant", item.Applicant);
                    command.Parameters.AddWithValue("@Major", item.Major);
                    command.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    command.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    command.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    command.Parameters.AddWithValue("@Completion_Percent ", item.CompletionPercent);

                    _sqlcon.Open();
                    command.ExecuteNonQuery();
                    _sqlcon.Close();

                }

            }
        }
        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<ApplicantEducationPoco> GetAll(params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {

            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {

                SqlCommand command = new SqlCommand();
                command.Connection = _sqlcon;
                command.CommandText = @"SELECT [Id]
                                      ,[Applicant]
                                      ,[Major]
                                      ,[Certificate_Diploma]
                                      ,[Start_Date]
                                      ,[Completion_Date]
                                      ,[Completion_Percent]
                                      ,[Time_Stamp]
                                  FROM [dbo].[Applicant_Educations]";
                _sqlcon.Open();
                SqlDataReader reader = command.ExecuteReader();
                ApplicantEducationPoco[] items = new ApplicantEducationPoco[500];
                int index = 0;
                while (reader.Read())
                {
                    ApplicantEducationPoco item = new ApplicantEducationPoco();
                    item.Id = reader.GetGuid(0);
                    item.Applicant = reader.GetGuid(1);
                    item.Major = reader.GetString(2);
                    item.CertificateDiploma = reader.GetString(3);
                    item.StartDate = reader.GetDateTime(4);
                    item.CompletionDate = reader.GetDateTime(5);
                    item.CompletionPercent = reader.GetByte(6);
                    item.TimeStamp = (byte[])reader[7];

                    items[index] = item;
                    index++;

                }
                _sqlcon.Close();
                return items.Where(a => a != null).ToList();
            }
        }

        public IList<ApplicantEducationPoco> GetList(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantEducationPoco GetSingle(Expression<Func<ApplicantEducationPoco, bool>> where, params Expression<Func<ApplicantEducationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantEducationPoco> items = GetAll().AsQueryable();
            return items.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (ApplicantEducationPoco item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"DELETE FROM[dbo].[Applicant_Educations]
                                   WHERE  [Id]= @Id";
                    command.Parameters.AddWithValue("@Id", item.Id);
                    _sqlcon.Open();
                    command.ExecuteNonQuery();
                    _sqlcon.Close();
                }
            }
        }

        public void Update(params ApplicantEducationPoco[] items)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (var item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"UPDATE [dbo].[Applicant_Educations]
                                           SET 
                                               [Applicant] = @Applicant
                                              ,[Major] = @Major
                                              ,[Certificate_Diploma] = @Certificate_Diploma
                                              ,[Start_Date] = @Start_Date
                                              ,[Completion_Date] = @Completion_Date
                                              ,[Completion_Percent] = @Completion_Percent
                                         WHERE  [Id]= @Id";

                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Applicant", item.Applicant);
                    command.Parameters.AddWithValue("@Major", item.Major);
                    command.Parameters.AddWithValue("@Certificate_Diploma", item.CertificateDiploma);
                    command.Parameters.AddWithValue("@Start_Date", item.StartDate);
                    command.Parameters.AddWithValue("@Completion_Date", item.CompletionDate);
                    command.Parameters.AddWithValue("@Completion_Percent ", item.CompletionPercent);

                    _sqlcon.Open();
                    command.ExecuteNonQuery();
                    _sqlcon.Close();

                }

            }
        }

    }
}
}
