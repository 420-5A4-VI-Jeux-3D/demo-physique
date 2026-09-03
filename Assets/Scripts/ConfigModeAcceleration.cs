using TMPro;
using UnityEngine;

/// <summary>
/// Panneau de configuration pour le mode de force "Acceleration"
/// </summary>
public class ConfigModeAcceleration : ConfigModeForceAbstrait
{
    [SerializeField, Tooltip("Champ de saisie de l'accélération")]
    private TMP_InputField acceleration;

    /// <inheritdoc/>
    public override void Lancer(Projectile projectile)
    {
        projectile.Lancer(1.0f, LireValeur(acceleration.text), ForceMode.Acceleration);
    }
}
