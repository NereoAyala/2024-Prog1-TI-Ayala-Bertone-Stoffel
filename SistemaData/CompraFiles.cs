using Newtonsoft.Json;
using SistemaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaData
{
    public class CompraFiles
    {
        private static string CompraFile = Path.GetFullPath("Compra.json");

        public static List<CompraEntity> LeerSuscripcionesDesdeJson()
        {
            if (File.Exists($"{CompraFile}"))
            {
                var json = File.ReadAllText($"{CompraFile}");
                return JsonConvert.DeserializeObject<List<CompraEntity>>(json);
            }
            else
            {
                return new List<CompraEntity>();
            }
        }

        public static void EscribirSuscripcion(CompraEntity compra)
        {
            List<CompraEntity> compras = LeerSuscripcionesDesdeJson();

            if (compra.IdCompra == 0)
            {
                compra.IdCompra = compras.Count() + 1;
            }
            else
            {
                compras.RemoveAll(x => x.IdCompra == compra.IdCompra);
            }


            compras.Add(compra);

            string json = JsonConvert.SerializeObject(compras, Formatting.Indented);
            File.WriteAllText($"{compra}", json);
        }
    }
}
