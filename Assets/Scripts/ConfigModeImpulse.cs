using TMPro;
using UnityEngine;

/// <summary>
/// Panneau de configuration pour le mode de force impulsive.
/// </summary>
public class ConfigModeImpulse : ConfigModeForceAbstrait
{
    [SerializeField, Tooltip("Champ de saisie de la masse pour une force impulsive")]
    private TMP_InputField masseImpulse;

    [SerializeField, Tooltip("Champ de saisie de la force pour une force impulsive")]
    private TMP_InputField forceImpulse;

    [SerializeField, Tooltip("Champ d'affichage de la vitesse pour une force impulsive")]
    private TMP_Text resultatImpulse;

    /// <summary>
    /// Affiche la vitesse calculée à partir de la force et de la masse saisies par l'utilisateur.
    /// </summary>
    public void AfficherResultatImpulse()
    {
        resultatImpulse.text = "Vitesse : " + LireValeur(forceImpulse.text) / LireValeur(masseImpulse.text, 1.0f) + " m/s";
    }

    /// <inheritdoc/>
    public override void Lancer(Projectile projectile)
    {
        projectile.Lancer(LireValeur(masseImpulse.text, 1.0f), LireValeur(forceImpulse.text), ForceMode.Impulse);
    }
}
