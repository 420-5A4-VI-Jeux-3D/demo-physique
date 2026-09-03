using UnityEngine;

/// <summary>
/// Groupe de plancher qui détecte l'entrée et la sortie d'un projectile à l'aide de deux détecteurs de projectile.
/// </summary>
public class GroupePlancher : MonoBehaviour
{
    [SerializeField, Tooltip("Détecteur de projectile")]
    private DetecteurProjectile detecteurProjectileEntre;

    [SerializeField, Tooltip("Détecteur de projectile")]
    private DetecteurProjectile detecteurProjectileSorti;

    /// <summary>
    /// Invoqué lorsque le projectile entre dans le groupe de plancher.
    /// </summary>
    public event System.Action projectileEntre;

    /// <summary>
    /// Invoqué lorsque le projectile sort du groupe de plancher.
    /// </summary>
    public event System.Action projectileSorti;

    private void Start()
    {
        // Écoute les événements des détecteurs de projectile et les retransmet en tant qu'événements du groupe de plancher.
        detecteurProjectileEntre.projectileEntre += () => { projectileEntre?.Invoke(); };
        detecteurProjectileSorti.projectileSorti += () => { projectileSorti?.Invoke(); };
    }
}
