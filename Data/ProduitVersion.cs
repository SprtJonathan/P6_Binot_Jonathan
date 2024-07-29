namespace P6_Binot_Jonathan.Data
{
    public class ProduitVersion
    {
        public int Id { get; set; }
        public int IdProduit { get; set; }
        public int IdVersion { get; set; }

        public virtual Produit Produit { get; set; }

        public virtual Version Version { get; set; }
    }
}
