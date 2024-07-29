namespace P6_Binot_Jonathan.Data
{
    public class ProduitSysteme
    {
        public int Id { get; set; }
        public int IdProduitVersion { get; set; }
        public int IdSysteme { get; set; }

        public virtual ProduitVersion ProduitVersion { get; set; }

        public virtual Systeme Systeme { get; set; }
    }
}
