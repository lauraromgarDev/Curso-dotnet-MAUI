using System;
using System.Collections.Generic;
using System.Text;

namespace Phoneword
{
    public static class PhonewordTranslator
    {
        /**
         * Este metodo toma una cadena de texto y la convierte en un número de teléfono. 
         * Si la cadena contiene caracteres no válidos, devuelve null.
         */
        public static string? ToNumber(string cadena)
        {
            if (string.IsNullOrWhiteSpace(cadena))
                return null;

            cadena = cadena.ToUpperInvariant();

            var numeroConvertido = new StringBuilder();
            foreach (var c in cadena)
            {
                if (" -0123456789".Contains(c))
                    numeroConvertido.Append(c);
                else
                {
                    var result = TranslateToNumber(c);
                    if (result != null)
                        numeroConvertido.Append(result);
                    // Bad character?
                    else
                        return null;
                }
            }
            return numeroConvertido.ToString();
        }

        /*
         * El método de extensión Contains se utiliza para verificar si un carácter específico está presente en una cadena.
         */

        static bool Contains(this string keyString, char c)
        {
            return keyString.IndexOf(c) >= 0;
        }


        /**
         * 
         * Este método toma un carácter y devuelve el número correspondiente en un teclado de teléfono. 
         * Si el carácter no es una letra válida, devuelve null.
         */

        static readonly string[] digits = {
        "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"
    };

        /**
         * Este método recorre el arreglo de cadenas "digits" para encontrar el carácter dado.
         * 
         */
        static int? TranslateToNumber(char c)
        {
            for (int i = 0; i < digits.Length; i++)
            {
                if (digits[i].Contains(c))
                    return 2 + i;
            }
            return null;
        }
    }
}
