using Capa_Modelo.Nodo;
using Capa_Modelo.Cliente;

namespace Capa_Modelo.Cola
{
    public class Cola_Banco : Nodo<Persona, Cola_Banco>
    {
        public override Persona Valor { get; set; }
        public override Cola_Banco Siguiente { get; set; }
        
        public Cola_Banco(Persona _valor)
        {
            Valor = _valor;
            Siguiente = null;
        }
    }
}
