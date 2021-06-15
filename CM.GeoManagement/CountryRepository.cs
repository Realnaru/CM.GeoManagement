using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM.GeoManagement
{
    public class CountryRepository
    {
        public void Add(Country country)
        {
            
            using (var connection = new SqlConnection("Server=WIN-QTLFNRNOL1C\\SQL2019;Database=Blaze2021;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("INSERT INTO [Countries] (CountryCode, CountryName) " + 
                    "VALUES( @CountryCode, @CountryName)", connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = country.CountryCode
                };

                var countryNameParam = new SqlParameter("@CountryName", SqlDbType.VarChar, 100)
                {
                    Value = country.CountryName
                };

                command.Parameters.Add(countryCodeParam);
                command.Parameters.Add(countryNameParam);
                command.ExecuteNonQuery();
            }
        }

        public Country Get(string countryCode)
        {
            using (var connection = new SqlConnection("Server=WIN-QTLFNRNOL1C\\SQL2019;Database=Blaze2021;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand(
                    "SELECT * FROM [Countries] WHERE CountryCode = @CountryCode", connection);

                var countryCodeParam = new SqlParameter("@CountryCode", SqlDbType.Char, 2)
                {
                    Value = countryCode
                };

                command.Parameters.Add(countryCodeParam);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Country()
                        {
                            CountryCode = reader["CountryCode"]?.ToString(),
                            CountryName = reader["CountryName"]?.ToString()
                        };
                    };
                }
                      
            }
            return null;
        }

        public void DeletAll()
        {

            using (var connection = new SqlConnection("Server=WIN-QTLFNRNOL1C\\SQL2019;Database=Blaze2021;Trusted_Connection=True;"))
            {
                connection.Open();

                var deleteRegions = new SqlCommand("DELETE FROM [Regions]", connection);


                deleteRegions.ExecuteNonQuery();
            }
            using (var connection = new SqlConnection("Server=WIN-QTLFNRNOL1C\\SQL2019;Database=Blaze2021;Trusted_Connection=True;"))
            {
                connection.Open();

                var command = new SqlCommand("DELETE FROM [Countries]", connection);

                
                command.ExecuteNonQuery();
            }
        }
    }
}
