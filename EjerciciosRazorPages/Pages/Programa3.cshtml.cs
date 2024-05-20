using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace EjerciciosRazorPages.Pages
{
    public class Programa3Model : PageModel
    {
        [BindProperty]
        public double a { get; set; }

        [BindProperty]
        public double b { get; set; }

        [BindProperty]
        public double x { get; set; }

        [BindProperty]
        public double y { get; set; }

        [BindProperty]
        public double n { get; set; }

        public StringBuilder ExpresionExpandida { get; set; }

        public double SumaTerminos { get; set; } 

        public void OnPost()
        {
            ExpresionExpandida = new StringBuilder();
            SumaTerminos = Evaluar(a, b, x, y, n); // Asignar el valor de la suma al propiedad
        }

        // Método para calcular el factorial de un número
        public double Factorial(double num)
        {
            if (num == 0)
                return 1;
            double resultado = 1;
            for (int i = 1; i <= num; i++)
            {
                resultado *= i;
            }
            return resultado;
        }


        // Método para calcular el coeficiente 
        public double calcularCoeficiene(double n, double k)
        {
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

   

    public double Evaluar(double a, double b, double x, double y, double n)
        {
            double ax = a * x;
            double by = b * y;
            double sumaTerminos = 0;

            ExpresionExpandida = new StringBuilder(); // Reiniciar el StringBuilder

            ExpresionExpandida.AppendLine($"Expansión de ({a}x + {b}y)^{n}:<br>");

            int k = 0;
            do
            {
                double coeficiente = calcularCoeficiene(n, k);
                // Calcular el término k
                double termino = coeficiente * Math.Pow(ax, n - k) * Math.Pow(by, k);
                ExpresionExpandida.AppendLine($"Término {k}: {termino}<br>");
                sumaTerminos += termino; // Acumular la suma de los términos
                k++;
            } while (k <= n);

            return sumaTerminos; // Devolver la suma de los términos
        }


}
}