using SistemaEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDTO
{
    public class ViajeDTO
    {
        [Required(ErrorMessage = "La fecha de entrega desde es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de entrega desde no es válida.")]
        public DateTime FechaEntregaDesde { get; set; }

        [Required(ErrorMessage = "La fecha de entrega hasta es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de entrega hasta no es válida.")]
        public DateTime FechaEntregaHasta { get; set; }

        // Método que valida las fechas de entrega
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Verificamos si la fecha de inicio de entrega es posterior a la fecha de fin de entrega
            if (FechaEntregaDesde > FechaEntregaHasta)
            {
                // Si la condición se cumple, se crea un mensaje de error
                yield return new ValidationResult(
                    // Mensaje que indica el problema con las fechas
                    "La fecha de entrega desde debe ser anterior o igual a la fecha de entrega hasta.",
                    // Array que contiene los nombres de las propiedades relacionadas con el error
                    new[] { nameof(FechaEntregaDesde), nameof(FechaEntregaHasta) }
                );
            }
        }


        //public void Validar(ResultadoEntity resultado)
        //{
        //    if (FechaEntregaDesde < DateTime.Now)
        //    {
        //        resultado.Errores.Add("La fecha no puede ser menor a la actual");
        //    }
        //    if (FechaEntregaHasta == FechaEntregaDesde.AddDays(7))
        //    {
        //        resultado.Errores.Add("La fecha tiene que ser 7 dias mayor a la fecha desde");
        //    }
        //}
    }
}
