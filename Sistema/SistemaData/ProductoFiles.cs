using EntitiesSistema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaData
{
    public class ProductoFiles
    {
        private static string ProductoFile = Path.GetFullPath("Producto.json");

        public static List<ProductoEntity> LeerSuscripcionesDesdeJson()
        {
            if (File.Exists($"{ProductoFile}"))
            {
                var json = File.ReadAllText($"{ProductoFile}");
                return JsonConvert.DeserializeObject<List<ProductoEntity>>(json);
            }
            else
            {
                return new List<ProductoEntity>();
            }
        }

        public static void EscribirSuscripcion(ProductoEntity producto)
        {
            List<ProductoEntity> productos = LeerSuscripcionesDesdeJson();

            if (producto.IdProducto == 0)
            {
                producto.IdProducto = productos.Count() + 1;
            }
            else
            {
                productos.RemoveAll(x => x.IdProducto == producto.IdProducto);
            }


            productos.Add(producto);

            string json = JsonConvert.SerializeObject(productos, Formatting.Indented);
            File.WriteAllText($"{producto}", json);
        }
    }
}
