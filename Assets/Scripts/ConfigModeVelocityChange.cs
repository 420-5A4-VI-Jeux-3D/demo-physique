using TMPro;
using UnityEngine;

/// <summary>
/// Panneau de configuration pour le mode de force "VelocityChange"
/// </summary>
public class ConfigModeVelocityChange : ConfigModeForceAbstrait
{
    [SerializeField, Tooltip("Champ de saisie de la vélocité")]
    private TMP_InputField velocite;

    /// <inheritdoc/>
    public override void Lancer(Projectile projectile)
    {
        projectile.Lancer(1.0f, LireValeur(velocite.text), ForceMode.VelocityChange);
    }
}
