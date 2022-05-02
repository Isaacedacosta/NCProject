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
    public static class WebServices
    {

        public static DataTable AllAttractions()
        {
            DbServices dbServices = new DbServices();
            DataTable dataTable = dbServices.ReadAll();
            dataTable.Columns.Add("DescricaoDisplay");
            dataTable.Columns.Add("nomeDisplay");
            dataTable.Columns.Add("localizacaoDisplay");
            dataTable.Columns.Add("cidadeDisplay");
            foreach(DataRow dr in dataTable.Rows)
            {
                string descricaoDisplay = "";
                string descricao = dr["Descricao"].ToString().Trim();
                if (descricao.Length > 13) { descricaoDisplay = descricao.Substring(0, 10) + "..."; }
                else { descricaoDisplay = descricao; }
                dr["DescricaoDisplay"] = descricaoDisplay;
            }
            return dataTable;
        }

        public static DataTable AttractionById(int Id)
        {
            DbServices dbServices = new DbServices();
            DataTable dataTable = dbServices.ReadById(Id);
            return dataTable;
        }

        public static string[] EstadosDisponiveis
        {
            get { return new string[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MS", "MT", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" }; }
        }

        public static bool AddAttraction(string nome, string descricao, string localizacao, string cidade, string estado)
        {
                TouristAttraction _attraction = new TouristAttraction();
                _attraction.Nome = nome;
                _attraction.Descricao = descricao;
                _attraction.Localizacao = localizacao;
                _attraction.Cidade = cidade;
                _attraction.Estado = estado;
                foreach (var property in _attraction.GetType().GetProperties())
                {
                    if(property.GetValue(_attraction).ToString() == "")
                    {
                        return false;
                    }
                };
            DbServices dbServices = new DbServices();
            return dbServices.Create(_attraction);
        }

        public static bool UpdateAttraction(int id, string nome, string descricao, string localizacao, string cidade, string estado)
        {
                TouristAttraction _attraction = new TouristAttraction();
                _attraction.Id = id;
                _attraction.Nome = nome;
                _attraction.Descricao = descricao;
                _attraction.Localizacao = localizacao;
                _attraction.Cidade = cidade;
                _attraction.Estado = estado;            
                foreach (var property in _attraction.GetType().GetProperties())
                {
                    if(property.GetValue(_attraction).ToString() == "")
                    {
                        return false;
                    }
                };
            DbServices dbServices = new DbServices();
            return dbServices.Update(_attraction);
        }

        public static bool DeleteAttraction(int id)
        {
            DbServices dbServices = new DbServices();
            return dbServices.Delete(id);
        }


        public static int NumberOfPages(DataTable dataTable)
        {
            int numberOfPages = (dataTable.Rows.Count / 4);
            if (dataTable.Rows.Count % 4 > 0) { numberOfPages++; }
            return numberOfPages;
        }

        public static DataTable GetAllPaginated(int requestIndex)
        {
            DataTable dt = AllAttractions();
            int numberOfPages = (dt.Rows.Count / 4);
            if (dt.Rows.Count % 4 > 0) { numberOfPages++; }

            int maxRowIndex = (requestIndex * 4);
            if (maxRowIndex <= dt.Rows.Count)
            {
                do
                {
                    try
                    {
                        dt.Rows.RemoveAt(maxRowIndex);
                    }
                    catch (Exception)
                    {
                    }
                } while (maxRowIndex < dt.Rows.Count);
            }

            int minRowIndex = (requestIndex * 4) - 4;
            for (int rowsToremove = minRowIndex; rowsToremove > 0; rowsToremove--)
            {
                dt.Rows.RemoveAt(0);
            }
            return dt;
        }
        public static DataTable GetBySearch(string searchTerm)
        {
            DbServices dbServices = new DbServices();
            DataTable dataTable = new DataTable();

            try
            {
                dataTable = dbServices.ReadBySearch(searchTerm);
            }
            catch (Exception)
            {
                return null;
            }
            return dataTable;

        }
        public static DataTable Filter(DataTable table, int requestIndex)
        {
            DataTable dataTable = table.Copy();

            int numberOfPages = (dataTable.Rows.Count / 4);
            if (dataTable.Rows.Count % 4 > 0) { numberOfPages++; }

            int maxRowIndex = (requestIndex * 4);
            if (maxRowIndex < dataTable.Rows.Count)
            {
                do
                {
                    dataTable.Rows.RemoveAt(maxRowIndex);
                } while (maxRowIndex < dataTable.Rows.Count);
            }

            int minRowIndex = (requestIndex * 4) - 4;
            for (int rowsToremove = minRowIndex; rowsToremove > 0; rowsToremove--)
            {
                try
                {
                    dataTable.Rows.RemoveAt(0);
                }
                catch (Exception)
                {
                    break;
                }
            }
            return dataTable;
        }

        public static string[] queryParser(string queryRecived)
        {
            string[] aResult = new string[2];
            string queryBusca = new StringBuilder(queryRecived.Substring(0, queryRecived.IndexOf("-atIndex"))).ToString();
            aResult[0] = queryBusca;
            string indexBusca = new StringBuilder(queryRecived.Substring(queryRecived.IndexOf("-atIndex")+8)).ToString();
            aResult[1] = indexBusca;
            return aResult;
        }

        public static string[] CarrosselButons(int indexBusca, int totalDePaginas, string Query)
        {
            string[] CarrosselButons = new string[2];
            int nextValue = indexBusca;
            int previousValue = indexBusca - 1;
            if (previousValue <= 0) { previousValue = 1; }
            CarrosselButons[0] = new StringBuilder($"{Query}-atIndex{previousValue}").ToString();

            if (totalDePaginas >= indexBusca) { nextValue++; }
            CarrosselButons[1] = new StringBuilder($"{Query}-atIndex{nextValue}").ToString();          

            return CarrosselButons;
        }
        
    }
}
