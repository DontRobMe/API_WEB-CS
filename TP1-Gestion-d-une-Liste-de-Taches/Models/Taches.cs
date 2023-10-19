namespace TP1_Gestion_d_une_Liste_de_Taches.Models;

public class Taches : Priorite
{
    public long id { get; set; }
    public string Name { get; set; }
    public bool Statut { get; set; }
    public priorite Priorite { get; set; }
    public long UtilisateurId { get; set; }
}