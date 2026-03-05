using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCatalog.Models
{
    // Definición de un MODELO usando RECORD (forma moderna y concisa de definir clases inmutables).
    // un record está diseñado específicamente para transportar datos.
    // Los parámetros entre paréntesis definen automáticamente las propiedades:
    // Title, Studio, Director y Year.
    public record Movie(String Title, String Studio, String Director, int Year);

}
