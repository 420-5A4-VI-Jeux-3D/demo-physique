using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Gère la création et la destruction des planchers dans la scène afin de suivre le déplacement du projectile. 
/// </summary>
public class GestionnaireSurface : MonoBehaviour
{
    [SerializeField, Tooltip("Préfab du groupe de plancher qui sera initialisé à répétion.")]
    private GroupePlancher prefabPlancher;

    [SerializeField, Tooltip("Position initiale en Z du premier plancher.")]
    private float positionInitialeZ;

    [SerializeField, Tooltip("Nombre de planchers à créer au démarrage. Est aussi le nombre de planchers maintenus dans la scène.")]
    private int nombrePlanchers = 5;

    // Longueur d'un plancher en unité Unity (mètres)
    private const float LONGUEUR_PLANCHER = 20.0f;

    // Emplacement du dernier plancher créé en Z
    private float dernierPlancherPositionZ = 0.0f;

    // Liste des planchers actuellement dans la scène. La queue permet de les supprimer en ordre d'ajout.
    private Queue<GroupePlancher> planchers;

    private void Awake()
    {
        planchers = new Queue<GroupePlancher>();
    }

    private void Start()
    {
        // Crée le premier plancher à la position initiale, puis les autres planchers sont créés derrière lui.
        dernierPlancherPositionZ = positionInitialeZ - LONGUEUR_PLANCHER;

        for (int i = 0; i < nombrePlanchers; i++)
        {
            AjouterPlancher();
        }
    }

    /// <summary>
    /// Ajoute un nouveau plancher à la scène, derrière le dernier plancher créé.
    /// </summary>
    private void AjouterPlancher()
    {
        GroupePlancher nouveauPlancher = Instantiate(prefabPlancher, transform);
        planchers.Enqueue(nouveauPlancher);

        // Positionne le nouveau plancher derrière le dernier plancher créé.
        float z = dernierPlancherPositionZ + LONGUEUR_PLANCHER;
        nouveauPlancher.transform.position = new Vector3(0.0f, 0.0f, z);
        dernierPlancherPositionZ = z;

        // Écoute les événements du plancher pour ajouter un nouveau plancher lorsque le projectile entre et détruire le plancher lorsque le projectile sort.
        nouveauPlancher.projectileEntre += AjouterPlancher;
        nouveauPlancher.projectileSorti += DetruirePlancher;
    }

    /// <summary>
    /// Détruit le plancher le plus ancien de la scène lorsque le projectile sort du plancher.
    /// </summary>
    private void DetruirePlancher()
    {
        GroupePlancher plancher = planchers.Dequeue();

        // Retire les événements pour éviter les fuites de mémoire.
        plancher.projectileEntre -= AjouterPlancher;
        plancher.projectileSorti -= DetruirePlancher;

        Destroy(plancher.gameObject);
    }
}
