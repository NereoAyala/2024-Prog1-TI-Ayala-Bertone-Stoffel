using SistemaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDTO
{
    public class ProductoDTO
    {
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int StockDisponible { get; set; }
        public double PrecioUnitario { get; set; }
        public int AltoCaja { get; set; }
        public int AnchoCaja { get; set; }
        public int ProfundidadCaja { get; set; }
        public int StockMinimo { get; set; }
        public void ValidarProducto(ResultadoEntity resultado) 
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                resultado.Errores.Add("El Nombre del Producto no es Valido");
            }
            if (string.IsNullOrEmpty(Marca))
            {
                resultado.Errores.Add("La Marca del Producto no es Valida");
            }
            if (StockDisponible<=0)
            {
                resultado.Errores.Add("El Stock del Producto no es Valido");
            }
            if (PrecioUnitario <= 0)
            {
                resultado.Errores.Add("El Precio Unitario del Producto no es Valido");
            }
            if (AltoCaja <= 0)
            {
                resultado.Errores.Add("El Alto de la Caja no es Valido");
            }
            if (AnchoCaja <= 0)
            {
                resultado.Errores.Add("El Ancho de la Caja no es Valido");
            }
            if (ProfundidadCaja <= 0)
            {
                resultado.Errores.Add("La Profundidad de la caja no es Valida");
            }
            if (StockMinimo<=0)
            {
                resultado.Errores.Add("El Stock Minimo no es Valido");
            }
        }
    }
}
