using TMPro;
using UnityEngine;

/// <summary>
/// Classe qui configure le mode de lancement d'un projectile en utilisant la force.
/// </summary>
public class ConfigModeForce : ConfigModeForceAbstrait
{
    [SerializeField, Tooltip("Champ de saisie de la masse pour une force")]
    private TMP_InputField masseForce;

    [SerializeField, Tooltip("Champ de saisie de la force pour une force")]
    private TMP_InputField forceForce;

    [SerializeField, Tooltip("Champ d'affichage de la vitesse pour une force")]
    private TMP_Text resultatForce;

    /// <summary>
    /// Affiche le résultat de l'accélération calculée à partir de la force et de la masse saisies par l'utilisateur.
    /// </summary>
    public void AfficherResultatForce()
    {
        resultatForce.text = "Accélération : " + LireValeur(forceForce.text) / LireValeur(masseForce.text, 1.0f) + " m/s^2";
    }

    /// <inheritdoc/>
    public override void Lancer(Projectile projectile)
    {
        projectile.Lancer(LireValeur(masseForce.text, 1.0f), LireValeur(forceForce.text), ForceMode.Force);
    }
}
