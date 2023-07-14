using Capa_Acceso_Datos.Txt;
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
        private Queue<Persona> cola_ventanilla = new Queue<Persona> ();
        private Queue<Persona> cola_plataforma = new Queue<Persona>();
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
        public void EjercicioPractico() {
            string contenido = Lea_ClientesJSON();

            List<Persona> personas = DeserializeJSON <List<Persona>>(contenido);

            CreeColas(personas);

            Plataformista();
            Cajero();
        }

        public string Lea_ClientesJSON() { 

            Lectura_Txt lectura = new Lectura_Txt();

            string contenido =lectura.Lee_Archivo("C:\\Users\\laboratorio\\source\\repos\\Programacion_3_Clase_8\\Hilos\\Clientes.json");

            return contenido;
        }

        public T DeserializeJSON<T>(string contenido) {

            Ayundate_JSON ayundante = new Ayundate_JSON();

            var resultado =ayundante.Deserialize_Modelo<T>(contenido);

            return resultado;
        }
        public void CreeColas(List<Persona> personas) {

            foreach (var persona in personas)
            {
                if (persona.Tramite=="Ventanilla")
                {
                    cola_ventanilla.Enqueue(persona);
                }
                else
                {
                    cola_plataforma.Enqueue(persona);
                }
            }        
        }

        public void Plataformista()
        {
            foreach (Persona persona in cola_plataforma)
            {
                Console.WriteLine("Se esta atendiando a la persona en plataforma: " + persona.Nombre);

                int tiempo_Espera = Tiempo_de_espera_de_acuerdo(persona.Telefono);

                Thread.Sleep(tiempo_Espera);

                if (persona.Identificacion == "")
                {
                    Identificacion_Vacia(persona.Identificacion);
                    //cola_plataforma.Enqueue(cola_plataforma.Dequeue());
                    Persona aux = cola_ventanilla.Dequeue();
                    cola_ventanilla.Enqueue(aux);
                }
            }
        }

        public void Cajero()
        {
            foreach (Persona persona in cola_ventanilla)
            {
                Console.WriteLine("Se esta atendiando a la persona en ventanilla: " + persona.Nombre);

                int tiempo_Espera = Tiempo_de_espera_de_acuerdo(persona.Telefono);

                Thread.Sleep(tiempo_Espera);

                if(persona.Identificacion == "") // string.isEmptyorNull(_identificacion) / null / string.Empty // hay distintas maneras de evaluar si esta vacio ese campo
                {
                    persona.Identificacion = Identificacion_Vacia(persona.Identificacion);
                    Persona aux = cola_ventanilla.Dequeue();
                    cola_ventanilla.Enqueue(aux);
                }
            }
        }

        public int Tiempo_de_espera_de_acuerdo(int _telefono)
        {
            if (_telefono < 5)
            {
                return 100;
            }
            else
            {
                return 300;
            }
        }

        public string Identificacion_Vacia(string _identificacion)
        {
            _identificacion = "Default"; 
            return _identificacion;
        }

    }
}
