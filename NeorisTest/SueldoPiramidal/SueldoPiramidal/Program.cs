using System;
using System.Collections.Generic;

namespace SueldoPiramidal
{
    class Program
    {
        static List<List<NodoTrabajador>> arbolTrabajadores;
        static Random rdValue = new Random();
        static RandomName rdName = new RandomName();
        static Trabajador trabajadorObj;
        static List<Trabajador> lstReclutados;
        static int idNode = 1;

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            RegistraTrabajadores();
            Console.WriteLine("---------------------Trabajadores sin Aumento:---------------------");
            MuestraPiramideLaboral();
            Console.Write("\nAumentar 10% desde el trabajador (identificador): ");
            int id = Convert.ToInt16(Console.ReadLine());
            AumentaSueldoPiramidal(id);
            Console.ReadKey();
        }

        static void RegistraTrabajadores()
        {
            arbolTrabajadores = new List<List<NodoTrabajador>>();
            arbolTrabajadores.Add(new List<NodoTrabajador>());
            trabajadorObj = new Trabajador(idNode, rdName.GetRandomName(), rdValue.Next(3000, 10000), new List<Trabajador>());
            arbolTrabajadores[0].Add(new NodoTrabajador(trabajadorObj, idNode, 0));
            int NoNiveles = rdValue.Next(1, 5);
            for (int i = 0; i < 1; i++)
            {
                arbolTrabajadores.Add(new List<NodoTrabajador>());
                for (int j = 0; j < arbolTrabajadores[i].Count; j++)
                    ExpandeNodoTrabajador(arbolTrabajadores[i][j], arbolTrabajadores[i][j].idm, (i + 1));
            }
        }

        static void ExpandeNodoTrabajador(NodoTrabajador Trabajador, int idf, int lev)
        {
            int NoReclutados = rdValue.Next(1, 10);
            string nombre; double ganancias;
            lstReclutados = new List<Trabajador>();

            for (int i = 0; i < NoReclutados; i++)
            {
                nombre = rdName.GetRandomName();
                ganancias = rdValue.Next(3000, 10000); idNode++;
                lstReclutados.Add(new Trabajador(idNode, nombre, ganancias, new List<Trabajador>()));
            }
            for (int i = 0; i < lstReclutados.Count; i++)
            {
                Trabajador.info.lstReclutados.Add(lstReclutados[i]); //Actualiza Lista de Reclutamiento.
                arbolTrabajadores[lev].Add(new NodoTrabajador(lstReclutados[i], lstReclutados[i].id, idf));
            }
        }

        static void MuestraPiramideLaboral()
        {
            for (int i = 0; i < arbolTrabajadores.Count; i++)
            {
                Console.WriteLine("Trabajadores del nivel " + (i + 1) + ": ");
                for (int j = 0; j < arbolTrabajadores[i].Count; j++)
                {
                    Console.Write("id: " + arbolTrabajadores[i][j].info.id + "; ");
                    Console.Write("Nombre: " + arbolTrabajadores[i][j].info.nombre + "; ");
                    Console.Write("Ganancias: " + arbolTrabajadores[i][j].info.ganancias + "; ");
                    Console.Write("Reclutado por: " + arbolTrabajadores[i][j].idf + ". \n");
                }
            }
        }

        static void AumentaSueldoPiramidal(int idS)
        {
            double ganancia; Boolean encontrado = false;
            for (int i = 0; i < arbolTrabajadores.Count; i++)
            {
                for (int j = 0; j < arbolTrabajadores[i].Count; j++)
                {
                    if (arbolTrabajadores[i][j].idm == idS)
                    {
                        ganancia = arbolTrabajadores[i][j].info.ganancias; encontrado = true;
                        arbolTrabajadores[i][j].info.ganancias = ganancia + ganancia * 0.1;
                        AumentaSueldoPiramidal((i + 1), arbolTrabajadores[i][j].idm); break;
                    }
                }
            }
            if (encontrado)
            {
                Console.WriteLine("\n---------------------Trabajadores con Aumento:---------------------");
                MuestraPiramideLaboral(); return;
            }
            Console.WriteLine("TRABAJADOR NO REGISTRADO.");
        }

        static void AumentaSueldoPiramidal(int i, int idp)
        {
            double ganancia;
            if (i < arbolTrabajadores.Count)
            {
                for (int j = 0; j < arbolTrabajadores[i].Count; j++)
                {
                    if (arbolTrabajadores[i][j].idf == idp)
                    {
                        ganancia = arbolTrabajadores[i][j].info.ganancias;
                        arbolTrabajadores[i][j].info.ganancias = ganancia + ganancia * 0.1;
                        AumentaSueldoPiramidal((i + 1), arbolTrabajadores[i][j].idm);
                    }
                }
            }
        }
    }
}