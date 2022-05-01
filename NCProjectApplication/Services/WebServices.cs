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
            DataTable db = dbServices.ReadAll();
            return db;
            //foreach (DataRow row in allLocations.Rows)
            //{
            //    TouristAttraction attraction = new TouristAttraction();
            //    attraction.Id = Convert.ToInt32(row["ID"]);
            //    attraction.Nome = Convert.ToString(row["Nome"]);
            //    attraction.Descricao = Convert.ToString(row["Descricao"]);
            //    attraction.Localizacao = Convert.ToString(row["Localizacao"]);
            //    attraction.Cidade = Convert.ToString(row["Cidade"]);
            //    attraction.Estado = Convert.ToString(row["Estado"]);

            //    touristAttractions.
            //}
        }

        public static bool AddAttraction(string nome, string descricao, string localizacao, string cidade, string estado)
        {
            TouristAttraction _attraction = new TouristAttraction();
            _attraction.Nome = nome;
            _attraction.Descricao = descricao;
            _attraction.Localizacao = localizacao;
            _attraction.Cidade = cidade;
            _attraction.Estado = estado;

            DbServices dbServices = new DbServices();
            return dbServices.Create(_attraction);
        }
    }
}
