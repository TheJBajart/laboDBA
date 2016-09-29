using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Labo1BDA
{
    class Program
    {
        static void Main(string[] args)
        {
            String connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Tets;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            String sql = "select s.fullname, s.Birthdate, s.Remark,c.Description from dbo.student s,dbo.Course c, dbo.StudentCourse sC where sC.StudentId = s.Id AND sC.CourseId = c.Id;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    String saveName = "";
                    while (reader.Read())
                    {
                        if(saveName.Equals("") || !saveName.Equals(reader[0]))
                        {
                            Console.WriteLine("nom :\t{0} \n date anniversaire : \t{1} \n note : \t{2} \n cours : \t{3}", reader[0], reader[1],reader[2],reader[3]);
                        }
                        Console.WriteLine(",\t{3}",reader[3]);
                        saveName = (string)reader[0];
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.ReadLine();

            }
            
        }
    }
}
