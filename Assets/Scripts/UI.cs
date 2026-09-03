using TMPro;
using UnityEngine;

/// <summary>
/// Effectue la gestion de l'interface utilisateur pour le lancement du projectile et l'affichage des résultats.
/// </summary>
public class UI : MonoBehaviour
{
    [SerializeField, Tooltip("Projectile à lancer")]
    private Projectile projectile;

    [SerializeField, Tooltip("Sélecteur du mode de force")]
    private TMP_Dropdown modeForce;

    #region panneaux
    [SerializeField, Tooltip("Panneaux de saisie")]
    private ConfigModeForceAbstrait[] panneaux;

    // Le panneau actif actuellement affiché
    private ConfigModeForceAbstrait panneauActif;
    #endregion

    #region Affichage des résultats
    [Header("Affichage des résultats")]
    [SerializeField, Tooltip("Champ d'affichage du temps simulé")]
    private TMP_Text tempsSimule;

    [SerializeField, Tooltip("Champ d'affichage de la vitesse actuelle")]
    private TMP_Text vitesseActuelle;

    [SerializeField, Tooltip("Champ d'affichage de l'accélération actuelle")]
    private TMP_Text accelerationActuelle;

    #endregion

    private void Start()
    {
        // Initialiser le panneau actif
        panneauActif = panneaux[modeForce.value];
        panneauActif.gameObject.SetActive(true);
    }

    private void Update()
    {
        // Mettre à jour les champs d'affichage des résultats
        if (projectile != null) {
            tempsSimule.text = $"Temps simulé : {projectile.TempsSimule:F4} s";
            vitesseActuelle.text = $"Vitesse actuelle : {projectile.Vitesse:F4} m/s";
            accelerationActuelle.text = $"Accélération actuelle : {projectile.Acceleration:F4} m/s²";
        }
    }

    /// <summary>
    /// Cette méthode est appelée lorsque l'utilisateur change le mode de force dans le menu déroulant.
    /// </summary>
    /// <param name="mode">L'indice du mode de force sélectionné</param>
    public void AfficherParametreMode(int mode)
    {
        if (mode < 0 || mode >= panneaux.Length) return;

        panneauActif.gameObject.SetActive(false);
        panneauActif = panneaux[mode];
        panneauActif.gameObject.SetActive(true);
    }

    /// <summary>
    /// Lance le projectile en utilisant le panneau actif pour récupérer les paramètres de force.
    /// </summary>
    public void Lancer()
    {
        panneauActif.Lancer(projectile);
    }

    /// <summary>
    /// Arrête le projectile en appelant la méthode Arreter() du projectile.
    /// </summary>
    public void Arreter()
    {
        projectile.Arreter();
    }


}
