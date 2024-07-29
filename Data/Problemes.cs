namespace P6_Binot_Jonathan.Data
{
    public class Problemes
    {
        public int Id { get; set; }
        public int IdProduitSysteme { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateResolution { get; set; }
        public int IdStatut { get; set; }
        public string Probleme { get; set; }
        public string? Resolution { get; set; }

        public virtual ProduitSysteme ProduitSysteme { get; set; }
        public virtual Statut Statut { get; set; }
    }
}
