using System;
using System.IO;

namespace IntroCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            int Opcion;
            do
            {
                Console.Write("\nMenú (Principal):\n0.- Salir.\n1.- Tipos de Datos.\n2.- Operadores.\n"
                 + "3.- TryCatch.\n4.- Switch.\n5.- Ciclos.\n6.- Vectores.\n7.- Matrices.\n"
                 + "8.- Archivos.\nOpción: ");
                Opcion = Convert.ToInt16(Console.ReadLine());
                switch (Opcion)
                {
                    case 0: Console.WriteLine("Presione una tecla."); break;
                    case 1: tiposDatos(); break;
                    case 2: operadores(); break;
                    case 3: defineTryCatch(); break;
                    case 4: switchCases(); break;
                    case 5: ciclos(); break;
                    case 6: vectores(); break;
                    case 7: matrices(); break;
                    case 8: archivos(); break;
                    default: Console.WriteLine("\nOpción Incorrecta."); break;
                }
            } while (Opcion != 0);
            Console.ReadKey(); //Presiona una tecla para cerrar consola.
        }
        public static void tiposDatos()
        {
            Console.WriteLine("\nTipos de datos más comunes en C#:");
            byte variableByte = 255;
            int varibaleInteger = 1200;
            double variableDouble = 150.55;
            Boolean variableBoleana = false;
            char variableChar = 'A';
            String variableString = "cadena";
            dynamic dynamicVariable = 77;
            Console.WriteLine("valor de la variable byte: " + variableByte);
            Console.WriteLine("valor de la variable int: " + varibaleInteger);
            Console.WriteLine("valor de la variable double: " + variableDouble);
            Console.WriteLine("valor de la variable boolean: " + variableBoleana);
            Console.WriteLine("valor de la variable char: " + variableChar);
            Console.WriteLine("valor de la variable String: " + variableString);
            Console.WriteLine("valor de la variable dinamyc: " + dynamicVariable);
        }


        public static void operadores()
        {
            operadoresAritmeticos();
            operadoresRelacionales();
        }
        public static void operadoresAritmeticos()
        {
            Console.WriteLine("\n---------------Operadores Aritméticos:------------------");
            int a, b, B, P; double R;
            Console.Write("a=");
            a = Convert.ToInt16(Console.ReadLine());
            Console.Write("b=");
            b = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\nOperaciones:");
            Console.WriteLine("Suma=" + (a + b));
            Console.WriteLine("Resta=" + (a - b));
            Console.WriteLine("División=" + (a / b));
            Console.WriteLine("Multiplicación=" + (a * b));
            Console.WriteLine("\nPotenciación:");
            Console.Write("Base=");
            B = Convert.ToInt16(Console.ReadLine());
            Console.Write("Potencia=");
            P = Convert.ToInt16(Console.ReadLine());
            R = Math.Pow(B, P);
            Console.WriteLine(B + "^" + P + "=" + R);
            Console.WriteLine("Sqrt(" + R + ")=" + Math.Sqrt(R));
        }

        public static void operadoresRelacionales()
        {
            Console.WriteLine("\n---------------Operadores Relacionales:---------------");
            double weight, height, IMC; //IMC --> Índice de masa corporal
            Console.Write("Peso (kg)=");
            weight = Convert.ToDouble(Console.ReadLine());
            Console.Write("Altura (m)=");
            height = Convert.ToDouble(Console.ReadLine());
            IMC = weight / (Math.Pow(height, 2));
            if (IMC > 0 && IMC < 18.5)
                Console.WriteLine("Usted tiene Bajo Peso.");
            else if (IMC >= 18.5 && IMC < 24.9)
                Console.WriteLine("Usted tiene Peso Normal.");
            else if (IMC >= 24.9 && IMC < 29.9)
                Console.WriteLine("Usted tiene Sobrepeso.");
            else if (IMC >= 29.9 && IMC < 34.5)
                Console.WriteLine("Usted tiene Obesidad (Grado 1).");
            else if (IMC >= 34.5 && IMC < 39.9)
                Console.WriteLine("Usted tiene Obesidad (Grado 2).");
            else if (IMC >= 39.9)
                Console.WriteLine("Usted tiene Obesidad (Grado 3).");
            else
                Console.WriteLine("IMC fuera de rango.");
        }

        public static void defineTryCatch()
        {
            Console.WriteLine("\nDefinición de TryCatch:");
            double prize, total; int amount;
            try
            {
                Console.Write("Precio/Unidad=");
                prize = Convert.ToDouble(Console.ReadLine());
                Console.Write("Número de unidades=");
                amount = Convert.ToInt16(Console.ReadLine());
                total = prize * amount;
                Console.WriteLine("Venta Total=" + total);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: " + e.Message);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        public static void switchCases()
        {
            int NoMes; Console.WriteLine("\nSwitch Case:");
            Console.Write("Número de mes=");
            NoMes = Convert.ToInt16(Console.ReadLine());
            switch (NoMes)
            {
                case 1: Console.WriteLine("Mes: Enero"); break;
                case 2: Console.WriteLine("Mes: Febrero"); break;
                case 3: Console.WriteLine("Mes: Marzo"); break;
                case 4: Console.WriteLine("Mes: Abril"); break;
                case 5: Console.WriteLine("Mes: Mayo"); break;
                case 6: Console.WriteLine("Mes: Junio"); break;
                case 7: Console.WriteLine("Mes: Julio"); break;
                case 8: Console.WriteLine("Mes: Agosto"); break;
                case 9: Console.WriteLine("Mes: Septiembre"); break;
                case 10: Console.WriteLine("Mes: Octubre"); break;
                case 11: Console.WriteLine("Mes: Noviembre"); break;
                case 12: Console.WriteLine("Mes: Diciembre"); break;
                default: Console.WriteLine("Mes: Fuera de rango"); break;
            }
        }

        public static void ciclos()
        {
            ciclosFor();
            ciclosWhile();
        }

        public static void ciclosFor()
        {
            Console.WriteLine("\n----------------------------Ciclos For:----------------------------");
            Console.WriteLine("Suma de los número de 1 a n:");
            int n, s = 0;
            Console.Write("n=");
            n = Convert.ToInt16(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                s += i;
                if (i < n)
                    Console.Write(i + "+");
                else
                    Console.Write(i + "=" + s);
            }

            Console.WriteLine("\n\nDetermina cuántas letras tiene una palabra:");
            String word; Char letter; int noLetters = 0;
            Console.Write("palabra=");
            word = Console.ReadLine();
            Console.Write("Letra=");
            letter = Convert.ToChar(Console.ReadLine());
            foreach (char character in word)
            {
                if (character == letter)
                    noLetters += 1;
            }
            Console.WriteLine("Número de letras '" + letter + "' en " + word + ": " + noLetters);
        }

        public static void ciclosWhile()
        {
            Console.WriteLine("\n----------------------------Ciclos While:----------------------------");
            Console.WriteLine("Muestra los números pares/impares/primos de 1 a n:");
            int n, num = 0;
            Console.Write("n=");
            n = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("\nNúmeros pares de 1 a " + n + ":");
            while (num < n)
            {
                num++;
                if (num % 2 == 0)
                    Console.Write(num + ", ");
            }
            Console.WriteLine(); num = 0;

            //Muestra los números impares de 1 a n:
            Console.WriteLine("\nNúmeros impares de 1 a " + n + ":");
            do
            {
                num++;
                if (num % 2 != 0)
                    Console.Write(num + ", ");
            } while (num < n);
            Console.WriteLine(); num = 0;

            //Muestra los números primos de 1 a n:
            Console.WriteLine("\nNúmeros primos de 1 a " + n + ":");
            while (num < n)
            {
                num++;
                if (numeroPrimo(num))
                    Console.Write(num + ", ");
            }
            Console.WriteLine();
        }

        public static Boolean numeroPrimo(int num)
        {
            if (num == 1)
                return false;
            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

        public static void vectores()
        {
            Console.WriteLine("\n----------------------------Vectores:----------------------------");
            Console.WriteLine("Producto suma de elementos vectoriales:");
            int[] vct; int ne, mul = 1, sum = 0;
            Console.Write("Número de elementos=");
            ne = Convert.ToInt16(Console.ReadLine());
            vct = new int[ne];
            for (int i = 0; i < vct.Length; i++)
            {
                Console.Write("Elemento " + (i + 1) + ": ");
                vct[i] = Convert.ToInt16(Console.ReadLine());
            }
            foreach (int num in vct)
            {
                mul *= num;
                sum += num;
            }
            Console.WriteLine("Suma=" + sum);
            Console.WriteLine("Multiplicación=" + mul);


        }

        public static void matrices()
        {
            Console.WriteLine("\n----------------------------Matrices:----------------------------");
            Console.WriteLine("Multiplicacion matricial:");
            int[,] m1, m2, m3;
            Console.WriteLine("\nMatriz 1:");
            m1 = ingresaDimensiones();
            Console.WriteLine("\nMatriz 2:");
            m2 = ingresaDimensiones();
            if (m1.GetLength(1) != m2.GetLength(0))
            {
                Console.WriteLine("\nNo se pueden multiplicar.");
                return;
            }
            Console.WriteLine("\nElementos de la Matriz 1:");
            leeMatriz(m1);
            Console.WriteLine("\nElementos de la Matriz 2:");
            leeMatriz(m2);
            Console.WriteLine("\nMatriz 1:");
            muestraMatriz(m1);
            Console.WriteLine("\nMatriz 2:");
            muestraMatriz(m2);
            m3 = multiplicaMatrices(m1, m2);
            Console.WriteLine("\nMatriz multiplicación:");
            muestraMatriz(m3);
        }

        public static int[,] ingresaDimensiones()
        {
            int nf, nc; int[,] M;
            Console.Write("Número de filas de la matriz: ");
            nf = Convert.ToInt16(Console.ReadLine());
            Console.Write("Número de columnas de matriz: ");
            nc = Convert.ToInt16(Console.ReadLine());
            M = new int[nf, nc];
            return M;
        }

        public static void leeMatriz(int[,] M)
        {
            int element;
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                {
                    Console.Write("Matriz[" + (i + 1) + "," + (j + 1) + "]=");
                    element = Convert.ToInt16(Console.ReadLine());
                    M[i, j] = element;
                }
            }
        }

        public static void muestraMatriz(int[,] M)
        {
            for (int i = 0; i < M.GetLength(0); i++)
            {
                for (int j = 0; j < M.GetLength(1); j++)
                    Console.Write(" " + M[i, j]);
                Console.WriteLine();
            }
        }

        public static int[,] multiplicaMatrices(int[,] M1, int[,] M2)
        {
            int[,] MM = new int[M1.GetLength(0), M1.GetLength(1)];
            for (int i = 0; i < M1.GetLength(0); i++)
            {
                for (int j = 0; j < M1.GetLength(1); j++)
                {
                    for (int k = 0; k < M2.GetLength(1); k++)
                        MM[i, k] += M1[i, j] * M2[j, k];
                }
            }
            return MM;
        }

        public static void archivos()
        {
            int opcion;
            do
            {
                Console.WriteLine("\n----------------------------Archivos----------------------------:");
                Console.Write("\n0.- Salir.\n1.- Crear.\n2.- Modificar.\n3.- Mostrar.\n4.- Depuración.\nOpción: ");
                opcion = Convert.ToInt16(Console.ReadLine());
                switch (opcion)
                {
                    case 0: break;
                    case 1: CrearArchivo(); break;
                    case 2: ModificarArchivo(); break;
                    case 3: MostrarArchivo(); break;
                    case 4: DepurarArchivos(); break;
                    default: Console.WriteLine("\nOpción Incorrecta."); break;
                }
            } while (opcion != 0);
        }

        public static void CrearArchivo()
        {
            Console.WriteLine("\nCrear y guardar un archivo de texto:");
            TextWriter file; String fileName, directoryRoute, line = " ";
            Console.Write("Nombre del Archivo: ");
            fileName = Console.ReadLine();
            Console.Write("Ruta de guardado: ");
            directoryRoute = Console.ReadLine();
            file = new StreamWriter(directoryRoute + fileName + ".txt");
            Console.WriteLine("Ingrese el texto: ");
            while (line.Length != 0)
            {
                line = Console.ReadLine();
                file.WriteLine(line);
            }
            file.Close(); Console.WriteLine("Archivo guardado.");
        }

        public static void ModificarArchivo()
        {
            Console.WriteLine("\nAbrir, Modificar y guardar un archivo de texto:");
            StreamWriter file; String fileRoute, line = " ";
            Console.Write("Ruta del archivo: ");
            fileRoute = Console.ReadLine();
            file = File.AppendText(fileRoute);
            Console.WriteLine("Texto que desea añadir: ");
            while (line.Length != 0)
            {
                line = Console.ReadLine();
                file.WriteLine(line);
            }
            file.Close(); Console.WriteLine("Archivo guardado.");
        }

        public static void MostrarArchivo()
        {
            Console.WriteLine("\nAbrir y mostrar un archivo de texto:");
            TextReader file; String fileRoute;
            Console.Write("Ruta del archivo: ");
            fileRoute = Console.ReadLine();
            file = new StreamReader(fileRoute);
            Console.WriteLine("\nContenido del documento textual:");
            Console.WriteLine(file.ReadToEnd());
        }

        public static void DepurarArchivos()
        {
            String route;
            Console.Write("Ruta: ");
            route = Console.ReadLine();
            string[] filesRoutes = Directory.GetFiles(route);
            foreach (string fileRoute in filesRoutes)
            {
                FileStream file = File.Open(fileRoute, FileMode.Open);
                file.SetLength(0); file.Close();
            }
            Console.WriteLine("\nArchivos Depurados.");
        }
    }
}