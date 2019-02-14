using System;

namespace ClientePositivo
{
    class Cliente
    {
        public String nombre, telefono;
        public double saldo;
        public Cliente() { }
        public Cliente(String nombre, String telefono, double saldo)
        {
            this.nombre = nombre; this.telefono = telefono; this.saldo = saldo;
        }
    }
}
