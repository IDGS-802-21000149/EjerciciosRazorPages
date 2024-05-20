using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EjerciciosRazorPages.Pages
{
    public class Programa2Model : PageModel
    {
        [BindProperty]
        public string? mensaje { get; set; }

        [BindProperty]
        public int N { get; set; }

        public string? mensajeCodificado = null;
        public string? mensajeDecodificado = null;

        public void OnPost()
        {
            mensaje = mensaje.ToUpper();

            string accion = Request.Form["action"];
            switch (accion)
            {
                case "codificar":
                    mensajeCodificado = Codificar(mensaje, N);
                    mensajeDecodificado = null;
                    break;
                case "decodificar":
                    mensajeDecodificado = Decodificar(mensaje, N);
                    mensajeCodificado = null;
                    break;
                default:
                    mensajeCodificado = null;
                    mensajeDecodificado = null; 
                    break;
            }
        }

        public string? Codificar(string mensaje, int n)
        {
            string resultado = "";
            // Recorrer cada letra del mensaje
            foreach (char letra in mensaje)
            {
                //Verificar si esta en rango
                if (letra >= 'A' && letra <= 'Z')
                {
                    //Codificar la letra, se pude usar el más por que el rango de las letras es de 26,esta definido en el sistema ASCII
                    char letraCodificada = (char)(letra + n);
                    //Si la letra codificada es mayor a Z, se le resta el rango de las letras y se le suma el valor de la primera letra
                    if (letraCodificada > 'Z')
                    {
                        letraCodificada = (char)(letraCodificada - 'Z' + 'A' - 1);
                    }
                    resultado += letraCodificada;
                }
                else
                {
                    resultado += letra;
                }
            }
            return resultado;
        }

        public string? Decodificar(string mensaje, int n)
        {
            string resultado = "";
            foreach (char letra in mensaje)
            {
                if (letra >= 'A' && letra <= 'Z')
                {
                    char letraDecodificada = (char)(letra - n);
                    if (letraDecodificada < 'A')
                    {
                        letraDecodificada = (char)(letraDecodificada + 'Z' - 'A' + 1);
                    }
                    resultado += letraDecodificada;
                }
                else
                {
                    resultado += letra;
                }
            }
            return resultado;
        }
    }
}
