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
    }
}
