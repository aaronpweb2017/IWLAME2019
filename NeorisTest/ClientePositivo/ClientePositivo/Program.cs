using System;
using System.Collections.Generic;

namespace ClientePositivo
{
    class Program
    {
        static Random rand = new Random(DateTime.Now.Second);
        static List<Cliente> lstClientes = new List<Cliente>();
        static RandomName randomName = new RandomName();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            InsertaClientes();
            Console.WriteLine("\nClientes (Desordenados):");
            MuestraClientes();
            OrdenaClientes();
            Console.WriteLine("\nClientes (Ordenados):");
            MuestraClientes();
            Console.WriteLine("\nCliente con el primer saldo (positivo):");
            PrimerSaldoPositivo();
            Console.ReadKey();
        }
        static void InsertaClientes()
        {
            int NoClientes = rand.Next(1, 100);
            String nombre, telefono; double saldo;
            for (int i = 0; i < NoClientes; i++)
            {
                nombre = randomName.GetRandomName();
                telefono = "521667" + Convert.ToString(rand.Next(1, 7)) 
                + Convert.ToString(rand.Next(10, 99)) 
                + Convert.ToString(rand.Next(10, 99)) 
                + Convert.ToString(rand.Next(10, 99));
                saldo = rand.Next(-5000, 5000);
                lstClientes.Add(new Cliente(nombre, telefono, saldo));
            }

        }
        static void OrdenaClientes()
        {
            double minor; List<Cliente> lstOrdCtes;
            lstOrdCtes = new List<Cliente>();
            for (int i = 0; i < lstClientes.Count; i++)
            {
                minor = lstClientes[0].saldo;
                lstOrdCtes.Add(GetMinorSaldo((i + 1), minor));
            }
            lstClientes = lstOrdCtes;
        }
        static Cliente GetMinorSaldo(int index, double minor)
        {
            Cliente cteMinorSaldo = new Cliente();
            int minorIndex = 0;
            for (int i = index; i < lstClientes.Count; i++)
            {
                if (lstClientes[i].saldo < minor)
                {
                    minor = lstClientes[i].saldo;
                    cteMinorSaldo = lstClientes[i];
                    minorIndex = i;
                }
            }
            if (minorIndex == 0)
                cteMinorSaldo = lstClientes[index - 1];
            lstClientes.Remove(cteMinorSaldo);
            return cteMinorSaldo;
        }
        static void MuestraClientes()
        {
            for (int i = 0; i < lstClientes.Count; i++)
                Console.WriteLine((i + 1) + ".- Nombre: " + lstClientes[i].nombre + " | Teléfono: " + lstClientes[i].telefono + " | Saldo: " + lstClientes[i].saldo);
        }
        static void PrimerSaldoPositivo()
        {
            for (int i = 0; i < lstClientes.Count; i++)
            {
                if (lstClientes[i].saldo > 0)
                {
                    Console.Write("Nombre: " + lstClientes[i].nombre + " | Teléfono: " + lstClientes[i].telefono + " | Saldo: " + lstClientes[i].saldo); break;
                }
            }
        }
    }
}
