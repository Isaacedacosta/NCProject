using NCProjectApplication.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCProjectApplication.Services
{
    public class DbServices
    {

        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog = NCProject; Integrated Security = True";

        #region Create
        public bool Create(TouristAttraction attraction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = $"INSERT INTO Locations (Nome, Descricao, Localizacao, Cidade, Estado, Data) VALUES ('{attraction.Nome}', '{attraction.Descricao}', '{attraction.Localizacao}', '{attraction.Cidade}', '{attraction.Estado}', '{attraction.DataCriacao.ToString("s")}');";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return false;
            }
        }
        #endregion

        public DataTable ReadAll()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = "SELECT * FROM Locations;";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    
                    adapter.Fill(table);

                    connection.Close();
                }
                return table;
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return null;
            }
        }

        public DataTable ReadById(int Id)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = $"SELECT * FROM Locations WHERE Id = {Id};";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;

                    
                    adapter.Fill(table);
                    connection.Close();
                }
                return table;
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return null;
            }
        }

        public bool Update(TouristAttraction attraction)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = $"UPDATE Locations SET Nome = '{attraction.Nome}', Descricao = '{attraction.Descricao}', Localizacao = '{attraction.Localizacao}', Cidade = '{attraction.Cidade}', Estado = '{attraction.Estado}' WHERE Id = {attraction.Id};";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = $"DELETE FROM Locations WHERE Id = {Id};";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return false;
            }
        }


        public DataTable ReadBySearch(string filter)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = $"SELECT * FROM Locations WHERE Nome LIKE '%{filter}%' UNION SELECT* FROM Locations WHERE Descricao LIKE '%{filter}%' UNION SELECT* FROM Locations WHERE Localizacao LIKE '%{filter}%' UNION SELECT* FROM Locations WHERE Cidade LIKE '%{filter}%' UNION SELECT* FROM Locations WHERE Estado LIKE '%{filter}%' ORDER BY Id;";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;

                    
                    adapter.Fill(table);
                    connection.Close();
                }
                    return table;
                
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return null;
            }
        }

        public DataTable OrderByNew()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = "SELECT * FROM Locations ORDER BY Data DESC;";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;


                    adapter.Fill(table);
                    connection.Close();
                }
                return table;

            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return null;
            }
        }

        public DataTable OrderByOld()
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string commandString = "SELECT * FROM Locations ORDER BY Data ASC;";
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = commandString;
                    connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;


                    adapter.Fill(table);
                    connection.Close();
                }
                return table;

            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return null;
            }
        }


    }
}
