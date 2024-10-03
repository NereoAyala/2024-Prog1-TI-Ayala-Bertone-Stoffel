using EntitiesSistema;
using Newtonsoft.Json;

namespace SistemaData
{
    public class CamionetaFiles
    {
        private static string CamionetaFile = Path.GetFullPath("Camioneta.json");

        public static List<CamionetaEntity> LeerSuscripcionesDesdeJson()
        {
            if (File.Exists($"{CamionetaFile}"))
            {
                var json = File.ReadAllText($"{CamionetaFile}");
                return JsonConvert.DeserializeObject<List<CamionetaEntity>>(json);
            }
            else
            {
                return new List<CamionetaEntity>();
            }
        }

        public static void EscribirSuscripcion(CamionetaEntity camioneta)
        {
            List<CamionetaEntity> camionetas = LeerSuscripcionesDesdeJson();

            if (camioneta.IdCamioneta==0)
            {
                camioneta.IdCamioneta = camionetas.Count() + 1;
            }
            else
            {
                camionetas.RemoveAll(x => x.IdCamioneta == camioneta.IdCamioneta);
            }


            camionetas.Add(camioneta);

            string json = JsonConvert.SerializeObject(camionetas, Formatting.Indented);
            File.WriteAllText($"{camioneta}", json);
        }
    }
}

