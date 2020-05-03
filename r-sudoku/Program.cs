// -----------------------------------------------
//               R - SUDOKU
//
//              Abril-Mayo 2020
//        nico.eus ǀ github.com/nicoagr      
// -----------------------------------------------
using System;
using System.Diagnostics;

namespace r_sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
        //Pantalla de Inicio
        Inicio:;
            Console.Title = "r-sudoku";
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("(r-sudoku) Resolvedor de sudoku de 9x9");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Este programa no utiliza ningún tipo de algoritmo,");
            Console.WriteLine("simplemente trabaja con la definición de sudoku, y hace");
            Console.WriteLine("los muchos cálculos necesarios para obtener cada casilla del");
            Console.WriteLine("sudoku. No es un programa eficiente, ni lo intenta ser.");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Versión 1.0 , creado por nicoagr");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("Presiona cualquier tecla para empezar...");
            Console.ReadLine();


            //Declarar variable maestra (Por motivos practicos, en vez de usar el comienzo de la variable(0) empiezo por el 1)
            int[,] memoria = new int[10, 10];

        //Imprimir sudoku
        Edicion:;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("(r-sudoku) Resolvedor de sudoku de 9x9");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(string.Empty);
            Console.WriteLine("Modo de edición. '0' Significa hueco en blanco");
            Console.WriteLine(string.Empty);
            Console.WriteLine("                     C   o   l   u   m   n   a");
            Console.WriteLine("               1   2   3     4   5   6     7   8   9");
            for (int i = 1; i <= 9; i++)
            {
                if (i == 4) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                if (i == 7) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                Console.WriteLine(string.Empty);
                Console.Write("Fila" + i + "          ");
                Console.Write(memoria[i, 1]);
                Console.Write(" ǀ ");
                Console.Write(memoria[i, 2]);
                Console.Write(" ǀ ");
                Console.Write(memoria[i, 3]);
                Console.Write(" ǀǀǀ ");
                Console.Write(memoria[i, 4]);
                Console.Write(" ǀ ");
                Console.Write(memoria[i, 5]);
                Console.Write(" ǀ ");
                Console.Write(memoria[i, 6]);
                Console.Write(" ǀǀǀ ");
                Console.Write(memoria[i, 7]);
                Console.Write(" ǀ ");
                Console.Write(memoria[i, 8]);
                Console.Write(" ǀ ");
                Console.Write(memoria[i, 9]);
            }

            //Proceso de elegir fila, columna y valor para editar una casilla
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Selecciona fila a cambiar, escribe 'ok' para confirmar, o 'reset' para volver a empezar.");
            string fila = Console.ReadLine();
            //Comprobar si hay alguin comando especial
            if (fila == "ok") goto ok;
            if (fila == "reset") { Console.WriteLine("Este proceso borrará todo el sudoku. Para confirmar, escribe 'reset'"); string confreset = Console.ReadLine(); if (confreset == "reset") memoria = new int[10, 10]; goto Edicion; }
            //errores varios
            if (fila == string.Empty) { goto Edicion; }
            try
            {
                int filaint = int.Parse(fila);
                //Caso especial, para en vez de poner 1 *Enter* 2 *Enter* 4 *Enter* poner 124 *enter*
                if (fila.Length == 3)
                {
                    int d1 = (int)fila[0] - 48;
                    int d2 = (int)fila[1] - 48;
                    int d3 = (int)fila[2] - 48;
                    memoria[d1, d2] = d3;
                    goto Edicion;
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Empty);
                Console.WriteLine("La fila tiene que ser un numero!");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadLine();
                goto Edicion;
            }
            if (fila.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Empty);
                Console.WriteLine("El valor de la fila tiene que estar entre 1 y 9!");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadLine();
                goto Edicion;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Que columna de la fila " + fila + " te gustaría cambiar?");
        column2:;
            string columna = Console.ReadLine();
            if (columna == string.Empty) { goto column2; }
            try
            {
                int columnaint = int.Parse(columna);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Empty);
                Console.WriteLine("La columna tiene que ser un numero!");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadLine();
                goto Edicion;
            }
            if (columna.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Empty);
                Console.WriteLine("El valor de la columna tiene que estar entre 1 y 9!");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadLine();
                goto Edicion;
            }
            Console.WriteLine("Introduce un valor para la casilla en la fila {0} y columna {1}", fila, columna);
            string valor = Console.ReadLine();
            try
            {
                int valorint = int.Parse(valor);
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Empty);
                Console.WriteLine("El valor tiene que ser un numero!");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadLine();
                goto Edicion;
            }
            if (valor.Length > 1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(string.Empty);
                Console.WriteLine("El valor tiene que estar entre 1 y 9!");
                Console.WriteLine("Presiona cualquier tecla para continuar...");
                Console.ReadLine();
                goto Edicion;
            }
            //Una vez pasados todos los errores, insertar el valor en la memoria
            memoria[int.Parse(fila), int.Parse(columna)] = int.Parse(valor);
            goto Edicion;

        // Imprimir sudoku y pedir confirmacion
        ok:;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            for (int i = 1; i < 10; i++)
            {
                if (i == 4) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                if (i == 7) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                Console.WriteLine(string.Empty);
                Console.Write("               ");
                if (memoria[i, 1] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 1]); }
                Console.Write(" ǀ ");
                if (memoria[i, 2] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 2]); }
                Console.Write(" ǀ ");
                if (memoria[i, 3] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 3]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 4] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 4]); }
                Console.Write(" ǀ ");
                if (memoria[i, 5] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 5]); }
                Console.Write(" ǀ ");
                if (memoria[i, 6] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 6]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 7] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 7]); }
                Console.Write(" ǀ ");
                if (memoria[i, 8] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 8]); }
                Console.Write(" ǀ ");
                if (memoria[i, 9] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 9]); }
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            Console.WriteLine("Por favor, confirma si este es el sudoku que quieres resolver y comprueba que está bien escrito");
            Console.WriteLine("Para confirmar, escribe '" + Environment.UserName + "' . Para salir, presiona cualquier tecla");
            string confirmacion = Console.ReadLine();
            if (confirmacion == Environment.UserName)
            {
                goto iniciarpensar;
            }
            else
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Pulsa cualquier tecla para volver al menu de edición.");
                Console.ReadLine();
                goto Edicion;

            }


        iniciarpensar:;
            //Definir cronometro para mostrar al final
            Stopwatch cron = new Stopwatch();
            //Empezar el cronometro
            cron.Start();
            //Imprimir sudoku inicial
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(cron.Elapsed); //debug
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            for (int i = 1; i < 10; i++)
            {
                if (i == 4) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                if (i == 7) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                Console.WriteLine(string.Empty);
                Console.Write("               ");
                if (memoria[i, 1] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 1]); }
                Console.Write(" ǀ ");
                if (memoria[i, 2] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 2]); }
                Console.Write(" ǀ ");
                if (memoria[i, 3] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 3]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 4] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 4]); }
                Console.Write(" ǀ ");
                if (memoria[i, 5] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 5]); }
                Console.Write(" ǀ ");
                if (memoria[i, 6] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 6]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 7] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 7]); }
                Console.Write(" ǀ ");
                if (memoria[i, 8] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 8]); }
                Console.Write(" ǀ ");
                if (memoria[i, 9] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 9]); }
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);


        pensar:;

            //Definir memoria temporal
            string temp;

            //Revisar cada fila
            for (int f = 1; f < 10; f++)
            {
                //revisar cada columna
                for (int c = 1; c < 10; c++)
                {
                    //Comprobar si hay numero, si lo hay, pasar
                    if (memoria[f, c] == 0) { } else goto haynumero;
                    //Resetear la memoria temporal
                    temp = "123456789";
                    //Revisar cada casilla de la fila de la casilla inicial
                    for (int casilla = 1; casilla < 10; casilla++)
                    {
                        // Si en la casilla no hay nada, ignora la memoria temporal para la casilla inicial
                        if (memoria[f, casilla] == 0) { }
                        else
                        {
                            // Si en la casilla hay un numero, quita ese numero de la memoria temporal
                            temp = temp.Replace(memoria[f, casilla].ToString(), string.Empty);
                        }
                    }
                    //Revisar cada casilla de la columna de la casilla inicial
                    for (int casilla = 1; casilla < 10; casilla++)
                    {
                        // Si en la casilla no hay nada, ignora la memoria temporal para la casilla inicial
                        if (memoria[casilla, c] == 0) { }
                        else
                        {
                            // Si en la casilla hay un numero, quita ese numero de la memoria temporal
                            temp = temp.Replace(memoria[casilla, c].ToString(), string.Empty);
                        }
                    }
                    //Revisar el recuadro 3x3 (sí, ya se que esto es poco práctico y que podía haber puesto más bucles, pero con el fin de
                    //mejorar las labores de mantenimiento he preferido ponerlo así y evitarme luego líos a la hora de arreglar cosas)
                    //Comprobar si está en las tres primeras filas
                    if (f >= 1 && f <= 3)
                    {
                        //Comprobar si esta en la columna 1 y 3
                        if (c >= 1 && c <= 3)
                        {
                            //Está en el primer cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[1, 1] == 0) { } else { temp = temp.Replace(memoria[1, 1].ToString(), string.Empty); }
                            if (memoria[1, 2] == 0) { } else { temp = temp.Replace(memoria[1, 2].ToString(), string.Empty); }
                            if (memoria[1, 3] == 0) { } else { temp = temp.Replace(memoria[1, 3].ToString(), string.Empty); }
                            if (memoria[2, 1] == 0) { } else { temp = temp.Replace(memoria[2, 1].ToString(), string.Empty); }
                            if (memoria[2, 2] == 0) { } else { temp = temp.Replace(memoria[2, 2].ToString(), string.Empty); }
                            if (memoria[2, 3] == 0) { } else { temp = temp.Replace(memoria[2, 3].ToString(), string.Empty); }
                            if (memoria[3, 1] == 0) { } else { temp = temp.Replace(memoria[3, 1].ToString(), string.Empty); }
                            if (memoria[3, 2] == 0) { } else { temp = temp.Replace(memoria[3, 2].ToString(), string.Empty); }
                            if (memoria[3, 3] == 0) { } else { temp = temp.Replace(memoria[3, 3].ToString(), string.Empty); }
                        }
                        //Comprobar si esta en la columna 4 y 6
                        if (c >= 4 && c <= 6)
                        {
                            //Está en el segundo cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[1, 4] == 0) { } else { temp = temp.Replace(memoria[1, 4].ToString(), string.Empty); }
                            if (memoria[1, 5] == 0) { } else { temp = temp.Replace(memoria[1, 5].ToString(), string.Empty); }
                            if (memoria[1, 6] == 0) { } else { temp = temp.Replace(memoria[1, 6].ToString(), string.Empty); }
                            if (memoria[2, 4] == 0) { } else { temp = temp.Replace(memoria[2, 4].ToString(), string.Empty); }
                            if (memoria[2, 5] == 0) { } else { temp = temp.Replace(memoria[2, 5].ToString(), string.Empty); }
                            if (memoria[2, 6] == 0) { } else { temp = temp.Replace(memoria[2, 6].ToString(), string.Empty); }
                            if (memoria[3, 4] == 0) { } else { temp = temp.Replace(memoria[3, 4].ToString(), string.Empty); }
                            if (memoria[3, 5] == 0) { } else { temp = temp.Replace(memoria[3, 5].ToString(), string.Empty); }
                            if (memoria[3, 6] == 0) { } else { temp = temp.Replace(memoria[3, 6].ToString(), string.Empty); }
                        }
                        //Comprobar si esta en la columna 7 y 9
                        if (c >= 7 && c <= 9)
                        {
                            //Está en el tercer cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[1, 7] == 0) { } else { temp = temp.Replace(memoria[1, 7].ToString(), string.Empty); }
                            if (memoria[1, 8] == 0) { } else { temp = temp.Replace(memoria[1, 8].ToString(), string.Empty); }
                            if (memoria[1, 9] == 0) { } else { temp = temp.Replace(memoria[1, 9].ToString(), string.Empty); }
                            if (memoria[2, 7] == 0) { } else { temp = temp.Replace(memoria[2, 7].ToString(), string.Empty); }
                            if (memoria[2, 8] == 0) { } else { temp = temp.Replace(memoria[2, 8].ToString(), string.Empty); }
                            if (memoria[2, 9] == 0) { } else { temp = temp.Replace(memoria[2, 9].ToString(), string.Empty); }
                            if (memoria[3, 7] == 0) { } else { temp = temp.Replace(memoria[3, 7].ToString(), string.Empty); }
                            if (memoria[3, 8] == 0) { } else { temp = temp.Replace(memoria[3, 8].ToString(), string.Empty); }
                            if (memoria[3, 9] == 0) { } else { temp = temp.Replace(memoria[3, 9].ToString(), string.Empty); }
                        }
                    }
                    //Comprobar si está en las tres segundas filas
                    if (f >= 4 && f <= 6)
                    {
                        //Comprobar si esta en la columna 1 y 3
                        if (c >= 1 && c <= 3)
                        {
                            //Está en el cuarto cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[4, 1] == 0) { } else { temp = temp.Replace(memoria[4, 1].ToString(), string.Empty); }
                            if (memoria[4, 2] == 0) { } else { temp = temp.Replace(memoria[4, 2].ToString(), string.Empty); }
                            if (memoria[4, 3] == 0) { } else { temp = temp.Replace(memoria[4, 3].ToString(), string.Empty); }
                            if (memoria[5, 1] == 0) { } else { temp = temp.Replace(memoria[5, 1].ToString(), string.Empty); }
                            if (memoria[5, 2] == 0) { } else { temp = temp.Replace(memoria[5, 2].ToString(), string.Empty); }
                            if (memoria[5, 3] == 0) { } else { temp = temp.Replace(memoria[5, 3].ToString(), string.Empty); }
                            if (memoria[6, 1] == 0) { } else { temp = temp.Replace(memoria[6, 1].ToString(), string.Empty); }
                            if (memoria[6, 2] == 0) { } else { temp = temp.Replace(memoria[6, 2].ToString(), string.Empty); }
                            if (memoria[6, 3] == 0) { } else { temp = temp.Replace(memoria[6, 3].ToString(), string.Empty); }
                        }
                        //Comprobar si esta en la columna 4 y 6
                        if (c >= 4 && c <= 6)
                        {
                            //Está en el quinto cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[4, 4] == 0) { } else { temp = temp.Replace(memoria[4, 4].ToString(), string.Empty); }
                            if (memoria[4, 5] == 0) { } else { temp = temp.Replace(memoria[4, 5].ToString(), string.Empty); }
                            if (memoria[4, 6] == 0) { } else { temp = temp.Replace(memoria[4, 6].ToString(), string.Empty); }
                            if (memoria[5, 4] == 0) { } else { temp = temp.Replace(memoria[5, 4].ToString(), string.Empty); }
                            if (memoria[5, 5] == 0) { } else { temp = temp.Replace(memoria[5, 5].ToString(), string.Empty); }
                            if (memoria[5, 6] == 0) { } else { temp = temp.Replace(memoria[5, 6].ToString(), string.Empty); }
                            if (memoria[6, 4] == 0) { } else { temp = temp.Replace(memoria[6, 4].ToString(), string.Empty); }
                            if (memoria[6, 5] == 0) { } else { temp = temp.Replace(memoria[6, 5].ToString(), string.Empty); }
                            if (memoria[6, 6] == 0) { } else { temp = temp.Replace(memoria[6, 6].ToString(), string.Empty); }
                        }
                        //Comprobar si esta en la columna 7 y 9
                        if (c >= 7 && c <= 9)
                        {
                            //Está en el sexto cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[4, 7] == 0) { } else { temp = temp.Replace(memoria[4, 7].ToString(), string.Empty); }
                            if (memoria[4, 8] == 0) { } else { temp = temp.Replace(memoria[4, 8].ToString(), string.Empty); }
                            if (memoria[4, 9] == 0) { } else { temp = temp.Replace(memoria[4, 9].ToString(), string.Empty); }
                            if (memoria[5, 7] == 0) { } else { temp = temp.Replace(memoria[5, 7].ToString(), string.Empty); }
                            if (memoria[5, 8] == 0) { } else { temp = temp.Replace(memoria[5, 8].ToString(), string.Empty); }
                            if (memoria[5, 9] == 0) { } else { temp = temp.Replace(memoria[5, 9].ToString(), string.Empty); }
                            if (memoria[6, 7] == 0) { } else { temp = temp.Replace(memoria[6, 7].ToString(), string.Empty); }
                            if (memoria[6, 8] == 0) { } else { temp = temp.Replace(memoria[6, 8].ToString(), string.Empty); }
                            if (memoria[6, 9] == 0) { } else { temp = temp.Replace(memoria[6, 9].ToString(), string.Empty); }
                        }
                    }
                    //Comprobar si está en las tres terceras filas
                    if (f >= 7 && f <= 9)
                    {
                        //Comprobar si esta en la columna 1 y 3
                        if (c >= 1 && c <= 3)
                        {
                            //Está en el septimo cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[7, 1] == 0) { } else { temp = temp.Replace(memoria[4, 1].ToString(), string.Empty); }
                            if (memoria[7, 2] == 0) { } else { temp = temp.Replace(memoria[4, 2].ToString(), string.Empty); }
                            if (memoria[7, 3] == 0) { } else { temp = temp.Replace(memoria[4, 3].ToString(), string.Empty); }
                            if (memoria[8, 1] == 0) { } else { temp = temp.Replace(memoria[5, 1].ToString(), string.Empty); }
                            if (memoria[8, 2] == 0) { } else { temp = temp.Replace(memoria[5, 2].ToString(), string.Empty); }
                            if (memoria[8, 3] == 0) { } else { temp = temp.Replace(memoria[5, 3].ToString(), string.Empty); }
                            if (memoria[9, 1] == 0) { } else { temp = temp.Replace(memoria[6, 1].ToString(), string.Empty); }
                            if (memoria[9, 2] == 0) { } else { temp = temp.Replace(memoria[6, 2].ToString(), string.Empty); }
                            if (memoria[9, 3] == 0) { } else { temp = temp.Replace(memoria[6, 3].ToString(), string.Empty); }
                        }
                        //Comprobar si esta en la columna 4 y 6
                        if (c >= 4 && c <= 6)
                        {
                            //Está en el quinto cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[7, 4] == 0) { } else { temp = temp.Replace(memoria[7, 4].ToString(), string.Empty); }
                            if (memoria[7, 5] == 0) { } else { temp = temp.Replace(memoria[7, 5].ToString(), string.Empty); }
                            if (memoria[7, 6] == 0) { } else { temp = temp.Replace(memoria[7, 6].ToString(), string.Empty); }
                            if (memoria[8, 4] == 0) { } else { temp = temp.Replace(memoria[8, 4].ToString(), string.Empty); }
                            if (memoria[8, 5] == 0) { } else { temp = temp.Replace(memoria[8, 5].ToString(), string.Empty); }
                            if (memoria[8, 6] == 0) { } else { temp = temp.Replace(memoria[8, 6].ToString(), string.Empty); }
                            if (memoria[9, 4] == 0) { } else { temp = temp.Replace(memoria[9, 4].ToString(), string.Empty); }
                            if (memoria[9, 5] == 0) { } else { temp = temp.Replace(memoria[9, 5].ToString(), string.Empty); }
                            if (memoria[9, 6] == 0) { } else { temp = temp.Replace(memoria[9, 6].ToString(), string.Empty); }
                        }
                        //Comprobar si esta en la columna 7 y 9
                        if (c >= 7 && c <= 9)
                        {
                            //Está en el sexto cuadrante.
                            //Comprobar uno por uno cada casilla del cuadrante
                            if (memoria[7, 7] == 0) { } else { temp = temp.Replace(memoria[7, 7].ToString(), string.Empty); }
                            if (memoria[7, 8] == 0) { } else { temp = temp.Replace(memoria[7, 8].ToString(), string.Empty); }
                            if (memoria[7, 9] == 0) { } else { temp = temp.Replace(memoria[7, 9].ToString(), string.Empty); }
                            if (memoria[8, 7] == 0) { } else { temp = temp.Replace(memoria[8, 7].ToString(), string.Empty); }
                            if (memoria[8, 8] == 0) { } else { temp = temp.Replace(memoria[8, 8].ToString(), string.Empty); }
                            if (memoria[8, 9] == 0) { } else { temp = temp.Replace(memoria[8, 9].ToString(), string.Empty); }
                            if (memoria[9, 7] == 0) { } else { temp = temp.Replace(memoria[9, 7].ToString(), string.Empty); }
                            if (memoria[9, 8] == 0) { } else { temp = temp.Replace(memoria[9, 8].ToString(), string.Empty); }
                            if (memoria[9, 9] == 0) { } else { temp = temp.Replace(memoria[9, 9].ToString(), string.Empty); }
                        }
                    }

                    //Si solo queda un numero posible en el recuadro, ponerlo
                    if (temp.Length == 1)
                    {
                        //Guardar el numero en la memoria
                        memoria[f, c] = int.Parse(temp);

                        //Resetear sudoku
                        Console.Clear();

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Pensando...");
                        Console.WriteLine(string.Empty);
                        Console.WriteLine(string.Empty);
                        for (int i = 1; i < 10; i++)
                        {
                            if (i == 4) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                            if (i == 7) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                            Console.WriteLine(string.Empty);
                            Console.Write("               ");
                            if (memoria[i, 1] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 1]); }
                            Console.Write(" ǀ ");
                            if (memoria[i, 2] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 2]); }
                            Console.Write(" ǀ ");
                            if (memoria[i, 3] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 3]); }
                            Console.Write(" ǀǀǀ ");
                            if (memoria[i, 4] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 4]); }
                            Console.Write(" ǀ ");
                            if (memoria[i, 5] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 5]); }
                            Console.Write(" ǀ ");
                            if (memoria[i, 6] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 6]); }
                            Console.Write(" ǀǀǀ ");
                            if (memoria[i, 7] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 7]); }
                            Console.Write(" ǀ ");
                            if (memoria[i, 8] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 8]); }
                            Console.Write(" ǀ ");
                            if (memoria[i, 9] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 9]); }
                        }
                        Console.WriteLine(string.Empty);
                        Console.WriteLine(string.Empty);


                        //Resetear todo el proceso (actualizar todo porque hay numero nuevo)
                        goto pensar;


                    }
                    if (temp.Length == 0) { } //Esto significa que aqui ya hay numero

                    //Debug
                    if (temp.Length < 3) { Console.WriteLine("Casilla con coordenadas [{0},{1}] tiene estas posibilidades: " + temp, f, c); }
                    if (cron.Elapsed > TimeSpan.FromSeconds(6)) goto forzaracabado;
                haynumero:;
                }
            }
            //Comprobar a ver si algun valor es 0. Si no, finalizar
            for (int f = 1; f < 10; f++)
            {
                //revisar cada columna
                for (int c = 1; c < 10; c++)
                {
                    if (memoria[f, c] == 0) { goto pensar; }
                }
            }

            //Imprimir sudoku por ultima vez cuando lo consigue resolver antes de 10 segundos
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("(r-sudoku) Resolvedor de sudoku de 9x9");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            for (int i = 1; i < 10; i++)
            {
                if (i == 4) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                if (i == 7) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                Console.WriteLine(string.Empty);
                Console.Write("               ");
                if (memoria[i, 1] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 1]); }
                Console.Write(" ǀ ");
                if (memoria[i, 2] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 2]); }
                Console.Write(" ǀ ");
                if (memoria[i, 3] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 3]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 4] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 4]); }
                Console.Write(" ǀ ");
                if (memoria[i, 5] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 5]); }
                Console.Write(" ǀ ");
                if (memoria[i, 6] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 6]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 7] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 7]); }
                Console.Write(" ǀ ");
                if (memoria[i, 8] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 8]); }
                Console.Write(" ǀ ");
                if (memoria[i, 9] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 9]); }
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine(string.Empty);
            cron.Stop();
            Console.WriteLine("Sudoku Resuelto en " + cron.Elapsed);
            Console.WriteLine("Presiona ENTER para cerrar");
            Console.ReadLine();
            Environment.Exit(0);

        // Forzar mostrar sudoku cuando han pasado 10 segundos (sudoku inacabado)
        forzaracabado:;
            cron.Stop();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine("(r-sudoku) Resolvedor de sudoku de 9x9");
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Este sudoku no ha podido ser resuelto, esto se debe a que algunas casillas");
            Console.WriteLine("tienen varias posibilidades. Se ha llegado hasta este punto:");
            Console.WriteLine(cron.Elapsed);
            Console.WriteLine(string.Empty);
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 1; i < 10; i++)
            {
                if (i == 4) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                if (i == 7) { Console.WriteLine(string.Empty); Console.Write("               --------------------------------------"); }
                Console.WriteLine(string.Empty);
                Console.Write("               ");
                if (memoria[i, 1] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 1]); }
                Console.Write(" ǀ ");
                if (memoria[i, 2] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 2]); }
                Console.Write(" ǀ ");
                if (memoria[i, 3] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 3]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 4] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 4]); }
                Console.Write(" ǀ ");
                if (memoria[i, 5] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 5]); }
                Console.Write(" ǀ ");
                if (memoria[i, 6] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 6]); }
                Console.Write(" ǀǀǀ ");
                if (memoria[i, 7] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 7]); }
                Console.Write(" ǀ ");
                if (memoria[i, 8] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 8]); }
                Console.Write(" ǀ ");
                if (memoria[i, 9] == 0) { Console.Write(" "); } else { Console.Write(memoria[i, 9]); }
            }
            Console.WriteLine(string.Empty);
            Console.WriteLine("");
            Console.WriteLine("Presiona ENTER para cerrar");
            Console.ReadLine();
            Environment.Exit(0);

        }
    }
}
