using Microsoft.AspNetCore.Authentication;

namespace ApiEventos.Modelo
{
    public class Meventos
    {
        public int id { get; set; }
        public string fecha { get; set; }
        public string descripcion { get; set; }
        public string lugar { get; set; }
        public decimal precio { get; set; }
        public bool estado { get; set; }
    }
}
