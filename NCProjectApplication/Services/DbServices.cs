﻿using NCProjectApplication.Entities;
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

                    DataTable table = new DataTable();
                    adapter.Fill(table);    

                    return table;
                }
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return null;
            }
        }

        public DataTable ReadById(int Id)
        {
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

                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    return table;
                }
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
                }
                return true;
            }
            catch (Exception exception)
            {
                string errorMessage = exception.Message;
                return false;
            }
        }
    }
}
