using System.Collections.Generic;

namespace App.Domain.DTO
{
    public class Abe_grafico_homeDTO
    {
        public List<Abe_grafico_01_homeDTO> lista_grafico_01 { get; set; }
        public List<Abe_grafico_02_homeDTO> lista_grafico_02 { get; set; }
    }

    public class Abe_grafico_01_homeDTO
    {
        public int total { get; set; }
        public string tip_descricao { get; set; }
    }
    public class Abe_grafico_02_homeDTO
    {
        public int total { get; set; }
        public string col_descricao { get; set; }
    }
}
