using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Programa1Model : PageModel
    {
        [BindProperty]
        public string peso { get; set; }

        [BindProperty]
        public string altura { get; set; }

        public double resultado = 0;
        public string reporte = "";


        public void OnPost()
        {
            double peso = Convert.ToDouble(this.peso);
            double altura = Convert.ToDouble(this.altura);
            resultado = peso / (altura * altura);
            reporte = informe(resultado);


        }


        public string informe(double resultado)
        {
            if (resultado < 18)
            {
                return "Bajo peso";
            }
            else if (resultado >= 18 && resultado < 25)
            {
                return "Normal";
            }
            else if (resultado >= 25 && resultado < 27)
            {
                return "Sobrepeso";
            }
            else if (resultado >= 27 && resultado < 30)
            {
                return "Obesidad grado I";
            }
            else if (resultado >= 30 && resultado < 40)
            {
                return "Obesidad grado II";
            }
            else if (resultado >= 40)
            {
                return "Obesidad grado III";
            }
            else
            {
                return "Error: ingrese datos válidos";
            }
        }
    }
}

