namespace EntitiesSistema
{
    public class ProductoEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int AltoCaja { get; set; }
        public int AnchoCaja { get; set; }
        public int ProfundidadCaja { get; set; }
        public double Precio { get; set; }
        public int StockDisponible { get; set; }
        public int StockMinimo { get; set; }
    }
}
