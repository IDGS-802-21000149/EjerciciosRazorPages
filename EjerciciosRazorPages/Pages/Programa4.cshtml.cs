using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace EjerciciosRazorPages.Pages
{
    public class Programa4Model : PageModel
    {
        public int[]? arreglo { get; set; }
        public double? promedio { get; set; }
        public int? moda { get; set; }
        public double? mediana { get; set; }
        public double? sumaTotal { get; set; }

        public void OnPost()
        {
            arreglo = GenerarArreglo();
            promedio = CalcularPromedio(arreglo);
            moda = CalcularModa(arreglo);
            mediana = CalcularMediana(arreglo);
            sumaTotal = SumarElementos(arreglo);
        }

        public int[] GenerarArreglo()
        {
            int[] arreglo = new int[20];
            Random random = new Random();
            for (int i = 0; i < arreglo.Length; i++)
            {
                arreglo[i] = random.Next(1, 100);
            }
            return arreglo;
        }

        public double SumarElementos(int[] arreglo)
        {
            double suma = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                suma += arreglo[i];
            }
            return suma;
        }

        public double CalcularPromedio(int[] arreglo)
        {
            double promedio = SumarElementos(arreglo) / arreglo.Length;
            return promedio;
        }

        public int CalcularModa(int[] arreglo)
        {
            int moda = 0;
            int repeticiones = 0;
            for (int i = 0; i < arreglo.Length; i++)
            {
                int contador = 0;
                for (int j = 0; j < arreglo.Length; j++)
                {
                    if (arreglo[i] == arreglo[j])
                    {
                        contador++;
                    }
                }
                if (contador > repeticiones)
                {
                    moda = arreglo[i];
                    repeticiones = contador;
                }
            }
            return moda;
        }

        public double CalcularMediana(int[] arreglo)
        {
            Array.Sort(arreglo);
            double mediana = 0;
            if (arreglo.Length % 2 == 0)
            {
                mediana = (arreglo[arreglo.Length / 2] + arreglo[arreglo.Length / 2 - 1]) / 2.0;
            }
            else
            {
                mediana = arreglo[arreglo.Length / 2];
            }
            return mediana;
        }
    }
}
