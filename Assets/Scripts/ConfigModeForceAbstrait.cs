using UnityEngine;

/// <summary>
/// Panneau de configuration pour le mode de force appliqué au projectile par rigidbody. 
/// </summary>
public abstract class ConfigModeForceAbstrait : MonoBehaviour
{
    /// <summary>
    /// Lance le projectile avec les paramètres de configuration du mode de force.
    /// </summary>
    /// <param name="projectile">Le projectile à lancer.</param>
    public abstract void Lancer(Projectile projectile);

    /// <summary>
    /// Lit une valeur float à partir d'une chaîne de caractères. Si la conversion échoue ou si la valeur est négative ou nulle, retourne une valeur par défaut.
    /// </summary>
    /// <param name="valeur">La chaîne de caractères à convertir en float.</param>
    /// <param name="valeurDefaut">La valeur par défaut à utiliser en cas d'échec de la conversion ou si la valeur est négative ou nulle.</param>
    /// <returns>La valeur float convertie ou la valeur par défaut.</returns>
    protected float LireValeur(string valeur, float valeurDefaut = 0.0f)
    {
        if (float.TryParse(valeur, out float resultat))
        {
            if (resultat <= 0)
            {
                Debug.LogWarning($"Impossible d'utiliser des valeurs négatives ou nulles. Utilisation de la valeur par défaut : {valeurDefaut}");
                return valeurDefaut;
            }

            return resultat;    
        }
        else
        {
            Debug.LogWarning($"Impossible de convertir '{valeur}' en float. Utilisation de la valeur par défaut : {valeurDefaut}");
            return valeurDefaut;
        }
    }
}
