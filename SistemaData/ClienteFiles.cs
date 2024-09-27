using EntitiesSistema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaData
{
    public class ClienteFiles
    {

        private static string ClienteFile = Path.GetFullPath("Cliente.json");

        public static List<ClienteEntity> LeerSuscripcionesDesdeJson()
        {
            if (File.Exists($"{ClienteFile}"))
            {
                var json = File.ReadAllText($"{ClienteFile}");
                return JsonConvert.DeserializeObject<List<ClienteEntity>>(json);
            }
            else
            {
                return new List<ClienteEntity>();
            }
        }

        public static void EscribirSuscripcion(ClienteEntity cliente)
        {
            List<ClienteEntity> clientes = LeerSuscripcionesDesdeJson();

            if (cliente.DniCliente == 0)
            {
                cliente.DniCliente = clientes.Count() + 1;
            }
            else
            {
                clientes.RemoveAll(x => x.DniCliente == cliente.DniCliente);
            }


            clientes.Add(cliente);

            string json = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText($"{cliente}", json);
        }
    }
}

