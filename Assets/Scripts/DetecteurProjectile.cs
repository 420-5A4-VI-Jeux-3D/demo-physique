using UnityEngine;

/// <summary>
/// Détecteur de projectile qui déclenche des événements lorsqu'un projectile entre ou sort d'une zone.
/// </summary>
public class DetecteurProjectile : MonoBehaviour
{
    /// <summary>
    /// Le projectile est entré dans la zone de détection.
    /// </summary>
    public event System.Action projectileEntre;

    /// <summary>
    /// Le projectile est sorti de la zone de détection.
    /// </summary>
    public event System.Action projectileSorti;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            projectileEntre?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Projectile"))
        {
            projectileSorti?.Invoke();
        }
    }
}
