﻿using NCProjectApplication.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NCProjectApplication.Entities
{
    public class TouristAttraction
    {
        #region Properties

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        #endregion
    }
}
