using Capa_Logica.Ayudante;
using Capa_Modelo.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica.Orquestador_Ejemplo
{
    public class Orquestador_Ejemplo
    {
        public Orquestador_Ejemplo()
        {
            
        }

        public int Sume_Numeros(int numero_1,int numero_2) {
        
            return numero_1+numero_2;
        }

        public int Restes_Numeros(int numero_1,int numero_2) {
        
           return numero_1-numero_2;
        }
        public string Serialize_Persona()
        {
            Persona persona = new Persona();
            persona.Nombre = "Mario";
            persona.Identificacion = "207370155";
            persona.Tramite = "";
            persona.Universidad = "Latina";

            Ayundate_JSON ayundante = new Ayundate_JSON();
            string json = ayundante.Serialice_Modelo<Persona>(persona);
       
            return json;

        }

        public string Serialize_Personas() {

            Persona persona_1 = new Persona();
            persona_1.Nombre = "Mario";
            persona_1.Identificacion = "207370155";
            persona_1.Tramite = "";
            persona_1.Universidad = "Latina";

            Persona persona_2 = new Persona();
            persona_2.Nombre = "Luis";
            persona_2.Identificacion = "123456789";
            persona_2.Tramite = "";
            persona_2.Universidad = "Latina";

            List<Persona> personas = new List<Persona>();
            personas.Add(persona_1);
            personas.Add(persona_2);

            Ayundate_JSON ayundante = new Ayundate_JSON();
            string json=ayundante.Serialice_Modelo<List<Persona>>(personas);

            return json;



        }

        public Estudiante Deserialize_Estudiante(string json) {

            Ayundate_JSON ayundante = new Ayundate_JSON();

            Estudiante nuevoEstudiante = ayundante.Deserialize_Modelo<Estudiante>(json);
            
            return nuevoEstudiante;
        }

    }
}
