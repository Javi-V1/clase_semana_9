// See https://aka.ms/new-console-template for more information

using Capa_Logica.Orquestador_Ejemplo;
using Capa_Modelo.Cliente;

Orquestador_Ejemplo orquestador = new Orquestador_Ejemplo();
Estudiante estudiante = orquestador.Deserialize_Estudiante("");
Console.WriteLine(estudiante.Identificacion);
