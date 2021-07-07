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
    public class ApplicantProfileRepository : IDataRepository<ApplicantProfilePoco>
    {
        private readonly string _connStr;
        SqlConnection _sqlcon;

        public ApplicantProfileRepository()
        {
            var config = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            config.AddJsonFile(path, false);
            var root = config.Build();
            _connStr = root.GetSection("ConnectionStrings").GetSection("DataConnection").Value;
            _sqlcon = new SqlConnection(_connStr);
        }
        public void Add(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (ApplicantProfilePoco item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"INSERT INTO [dbo].[Applicant_Profiles]
                                       ([Id]
                                       ,[Login]
                                       ,[Current_Salary]
                                       ,[Current_Rate]
                                       ,[Currency]
                                       ,[Country_Code]
                                       ,[State_Province_Code]
                                       ,[Street_Address]
                                       ,[City_Town]
                                       ,[Zip_Postal_Code])
                                 VALUES
                                      (
                                       @Id
                                       ,@Login
                                       ,@Current_Salary
                                       ,@Current_Rate
                                       ,@Currency
                                       ,@Country_Code
                                       ,@State_Province_Code
                                       ,@Street_Address
                                       ,@City_Town
                                       ,@Zip_Postal_Code)";


                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Login", item.Login);
                    command.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    command.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    command.Parameters.AddWithValue("@Currency", item.Currency);
                    command.Parameters.AddWithValue("@Country_Code", item.Country);
                    command.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    command.Parameters.AddWithValue("@Street_Address", item.Street);
                    command.Parameters.AddWithValue("@City_Town", item.City);
                    command.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);

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

        public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {

                SqlCommand command = new SqlCommand();
                command.Connection = _sqlcon;
                command.CommandText = @"SELECT [Id]
                                  ,[Login]
                                  ,[Current_Salary]
                                  ,[Current_Rate]
                                  ,[Currency]
                                  ,[Country_Code]
                                  ,[State_Province_Code]
                                  ,[Street_Address]
                                  ,[City_Town]
                                  ,[Zip_Postal_Code]
                                  ,[Time_Stamp]
                              FROM [dbo].[Applicant_Profiles]";
                _sqlcon.Open();
                SqlDataReader reader = command.ExecuteReader();
                ApplicantProfilePoco[] items = new ApplicantProfilePoco[500];
                int index = 0;
                while (reader.Read())
                {
                    ApplicantProfilePoco item = new ApplicantProfilePoco();
                    item.Id = reader.GetGuid(0);
                    item.Login = reader.GetGuid(1);
                    item.CurrentSalary = reader.GetDecimal(2);
                    item.CurrentRate = reader.GetDecimal(3);
                    item.Currency = reader.GetString(4);
                    item.Country = reader.GetString(5);
                    item.Province = reader.GetString(6);
                    item.Street = reader.GetString(7);
                    item.City = reader.GetString(8);
                    item.PostalCode = reader.GetString(9);
                    item.TimeStamp = (byte[])reader[10];


                    items[index] = item;
                    index++;

                }
                _sqlcon.Close();
                return items.Where(a => a != null).ToList();
            }
        }

        public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantProfilePoco> items = GetAll().AsQueryable();
            return items.Where(where).FirstOrDefault();
        }

        public void Remove(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection connection = new SqlConnection(_connStr))
            {
                foreach (ApplicantProfilePoco item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"DELETE FROM[dbo].[Applicant_Profiles]
                                   WHERE  [Id]= @Id";
                    command.Parameters.AddWithValue("@Id", item.Id);
                    _sqlcon.Open();
                    command.ExecuteNonQuery();
                    _sqlcon.Close();
                }
            }
        }

        public void Update(params ApplicantProfilePoco[] items)
        {
            using (SqlConnection _sqlcon = new SqlConnection(_connStr))
            {
                foreach (var item in items)
                {
                    SqlCommand command = new SqlCommand();
                    command.Connection = _sqlcon;
                    command.CommandText = @"UPDATE [dbo].[Applicant_Profiles]
                                       SET 
                                           [Login] = @Login
                                          ,[Current_Salary] =@Current_Salary
                                          ,[Current_Rate] = @Current_Rate
                                          ,[Currency] = @Currency
                                          ,[Country_Code] = @Country_Code
                                          ,[State_Province_Code] = @State_Province_Code
                                          ,[Street_Address] = @Street_Address
                                          ,[City_Town] = @City_Town
                                          ,[Zip_Postal_Code] = @Zip_Postal_Code
                                           WHERE  [Id]= @Id";

                    command.Parameters.AddWithValue("@Id", item.Id);
                    command.Parameters.AddWithValue("@Login", item.Login);
                    command.Parameters.AddWithValue("@Current_Salary", item.CurrentSalary);
                    command.Parameters.AddWithValue("@Current_Rate", item.CurrentRate);
                    command.Parameters.AddWithValue("@Currency", item.Currency);
                    command.Parameters.AddWithValue("@Country_Code", item.Country);
                    command.Parameters.AddWithValue("@State_Province_Code", item.Province);
                    command.Parameters.AddWithValue("@Street_Address", item.Street);
                    command.Parameters.AddWithValue("@City_Town", item.City);
                    command.Parameters.AddWithValue("@Zip_Postal_Code", item.PostalCode);

                    _sqlcon.Open();
                    command.ExecuteNonQuery();
                    _sqlcon.Close();

                }
            }
        }
    }
}
