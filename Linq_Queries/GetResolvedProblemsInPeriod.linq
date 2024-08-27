<Query Kind="Statements">
  <Connection>
    <ID>c468a030-cd87-434a-baff-f9ae5fa9a304</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>JONATHAN-LAPTOP\SQLEXPRESS</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>aspnet-P6_Binot_Jonathan</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

// Demande des paramètres à l'utilisateur
var produitNom = Util.ReadLine("Nom produit - optionnel: ", "Trader en Herbe, Maître des Investissements, Planificateur d’Entraînement, Planificateur d’Anxiété Sociale");
DateTime dateDebut = Util.ReadLine("Veuillez entrer la date de début:", new DateTime(2024, 1, 1));
DateTime dateFin = Util.ReadLine("Veuillez entrer la date de fin:", new DateTime(2024, 12, 31));
var versionNom = Util.ReadLine("Numéro version - optionnel: ", string.Empty);
var motsClés = Util.ReadLine("Mots clés - optionnel: ", string.Empty);

// Exécution de la requête avec les paramètres saisis
var result = Problemes
    .Join(ProduitSystemes,
        probleme => probleme.IdProduitSysteme,
        produitSysteme => produitSysteme.Id,
        (probleme, produitSysteme) => new { probleme, produitSysteme })
    .Join(ProduitVersions,
        ps => ps.produitSysteme.IdProduitVersion,
        produitVersion => produitVersion.Id,
        (ps, produitVersion) => new { ps.probleme, ps.produitSysteme, produitVersion })
    .Join(Produits,
        pv => pv.produitVersion.IdProduit,
        produit => produit.Id,
        (pv, produit) => new { pv.probleme, pv.produitSysteme, pv.produitVersion, produit })
    .Join(Versions,
        pv => pv.produitVersion.IdVersion,
        version => version.Id,
        (pv, version) => new { pv.probleme, pv.produitSysteme, pv.produitVersion, pv.produit, version })
    .Where(p => (string.IsNullOrEmpty(produitNom) || p.produit.Nom.Contains(produitNom)) &&
                p.probleme.DateCreation >= dateDebut &&
                p.probleme.DateCreation <= dateFin &&
                (string.IsNullOrEmpty(versionNom) || p.version.Nom == versionNom) &&
                (string.IsNullOrEmpty(motsClés) || p.probleme.Probleme.Contains(motsClés)) &&
                p.probleme.IdStatut == 1) // L'IdStatut 1 correspond à "Résolu"
    .Select(p => p.probleme)
    .ToList();

// Affichage des résultats
result.Dump();
