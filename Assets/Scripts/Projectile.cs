using UnityEngine;

/// <summary>
/// Projectile sur lequel on simule l'effet d'une force appliquée selon différents modes de force.
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    // Le rigidbody du projectile
    private Rigidbody rigidbody;

    #region Propriété pour le UI
    /// <summary>
    /// Temps depuis le debut de la simulation
    /// </summary>
    public float TempsSimule { get; private set; }

    /// <summary>
    /// Vitesse dans la dernière frame
    /// </summary>
    public float Vitesse { get; private set; }

    /// <summary>
    /// Accélération depuis la dernière frame
    /// </summary>
    public float Acceleration { get; private set;  }

    // Vitesse de la précédente frame
    private float vitessePrecedente;

    // Indique si une simulation a lieu
    private bool simulationEnCours;

    // La valeur simulée
    private float valeurSimulee;

    // Le mode de force simulé
    private ForceMode modeForceSimulee;

    #endregion

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        vitessePrecedente = 0.0f;
        TempsSimule = 0.0f;
        Vitesse = 0.0f;
        Acceleration = 0.0f;
    }

    /// <summary>
    /// Applique la force au projectile selon le mode de force choisi. Si la force est Impulsive ou de changement de vitesse, 
    /// la force est appliquée immédiatement. Si la force est continue, elle sera appliquée à chaque frame de simulation.
    /// </summary>
    /// <param name="masse">La masse du projectile.</param>
    /// <param name="valeur">La valeur de la force à appliquer.</param>
    /// <param name="mode">Le mode de force à utiliser.</param>
    public void Lancer(float masse, float valeur, ForceMode mode)
    {
        TempsSimule = 0.0f;

        simulationEnCours = true;
        rigidbody.mass = masse;
        valeurSimulee = valeur;
        modeForceSimulee = mode;

        if (mode == ForceMode.Impulse || mode == ForceMode.VelocityChange)
        {
            rigidbody.AddForce(valeur * Vector3.forward, mode);
        }
    }

    /// <summary>
    /// Arrête la simulation en cours et réinitialise la vitesse et l'accélération du projectile.
    /// </summary>
    public void Arreter()
    {
        rigidbody.linearVelocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        simulationEnCours = false; 
    }

    private void FixedUpdate()
    {
        if (simulationEnCours)
        {
            // Mettre à jour le temps simulé, la vitesse et l'accélération
            TempsSimule += Time.fixedDeltaTime;
            Vitesse = rigidbody.linearVelocity.magnitude;
            Acceleration = (Vitesse - vitessePrecedente) / Time.fixedDeltaTime;
            vitessePrecedente = Vitesse;

            // Appliquer la force continue si le mode de force est Acceleration ou Force
            if (modeForceSimulee == ForceMode.Acceleration || 
                modeForceSimulee == ForceMode.Force)
            {
                rigidbody.AddForce(valeurSimulee * Vector3.forward, modeForceSimulee);
            }
        }
    }
}
