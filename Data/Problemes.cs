namespace P6_Binot_Jonathan.Data
{
    public class Problemes
    {
        public int Id { get; set; }
        public int IdProduit { get; set; }
        public int IdVersion { get; set; }
        public int IdSysteme { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateResolution { get; set; }
        public int IdStatut { get; set; }
        public string Probleme { get; set; }
        public string? Resolution { get; set; }

        public virtual Produit Produit { get; set; }
        public virtual Version Version { get; set; }
        public virtual Systeme Systeme { get; set; }
        public virtual Statut Statut { get; set; }
    }
}
