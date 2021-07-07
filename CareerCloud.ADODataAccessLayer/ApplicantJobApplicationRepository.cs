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
    public class ApplicantJobApplicationRepository : IDataRepository<ApplicantJobApplicationPoco>
    {
        private readonly string _connStr;
        SqlConnection _sqlcon;

        public ApplicantJobApplicationRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            _sqlcon = new SqlConnection(_connStr);
        }
        public void Add(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (ApplicantJobApplicationPoco item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"INSERT INTO[dbo].[Applicant_Job_Applications]
                                               ([Id]
                                               ,[Applicant]
                                               ,[Job]
                                               ,[Application_Date])
                                         VALUES
                                               (@Id
                                               ,@Applicant
                                               ,@Job
                                               ,@Application_Date)";


                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Applicant", item.Applicant);
                    command.Parameters.AddWithValue("@Job", item.Job);
                    command.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);


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

        public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {

                SqlCommand command = new SqlCommand();
                command.Connection = _sqlcon;
                command.CommandText = @"SELECT [Id]
                                  ,[Applicant]
                                  ,[Job]
                                  ,[Application_Date]
                                  ,[Time_Stamp]
                              FROM [dbo].[Applicant_Job_Applications]";
                _sqlcon.Open();
                SqlDataReader reader = command.ExecuteReader();
                ApplicantJobApplicationPoco[] items = new ApplicantJobApplicationPoco[500];
                int index = 0;
                while (reader.Read())
                {
                    ApplicantJobApplicationPoco item = new ApplicantJobApplicationPoco();
                    item.Id = reader.GetGuid(0);
                    item.Applicant = reader.GetGuid(1);
                    item.Job = reader.GetGuid(2);
                    item.ApplicationDate = reader.GetDateTime(3);
                    item.TimeStamp = (byte[])reader[4];

                    items[index] = item;
                    index++;

                }
                _sqlcon.Close();
                return items.Where(a => a != null).ToList();
            }
        }

        public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantJobApplicationPoco> items = GetAll().AsQueryable();
            return items.Where(where).FirstOrDefault();
        }


        public void Remove(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (ApplicantJobApplicationPoco item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"DELETE FROM[dbo].[Applicant_Job_Applications]
                                   WHERE  [Id]= @Id";
                    command.Parameters.AddWithValue("@Id", item.Id);
                    _sqlcon.Open();
                    command.ExecuteNonQuery();
                    _sqlcon.Close();
                }
            }
        }

        public void Update(params ApplicantJobApplicationPoco[] items)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (var item in items)
                {
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = _sqlcon;
                    comm.CommandText = @"UPDATE [dbo].[Applicant_Job_Applications]
                                       SET 
                                           [Applicant] = @Applicant
                                          ,[Job] = @Job
                                          ,[Application_Date] = @Application_Date
                                          WHERE  [Id]= @Id";

                    comm.Parameters.AddWithValue("@Id", item.Id);
                    comm.Parameters.AddWithValue("@Applicant", item.Applicant);
                    comm.Parameters.AddWithValue("@Job", item.Job);
                    comm.Parameters.AddWithValue("@Application_Date", item.ApplicationDate);

                    _sqlcon.Open();
                    comm.ExecuteNonQuery();
                    _sqlcon.Close();

                }

            }
        }
    }

}
