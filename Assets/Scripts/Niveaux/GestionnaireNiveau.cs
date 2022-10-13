using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GestionnaireNiveau : MonoBehaviour
{
    [Header("Information générale")]
    public NiveauBase[] Niveaux;
    public Balle Balle;


    public event Action<INiveauInfo> OnNiveauActuelChanger;


    public void Awake()
    {
        foreach (var niveau in Niveaux)
        {
            niveau.OnNiveauReussi += OnNiveauReussi;
        }

        // trie pour éviter de retrier lors de changer de niveaux
        Niveaux = Niveaux.OrderBy(x => x.NoNiveau).ToArray();
    }

    void Start()
    {
        AllerAuNiveau(Niveaux.FirstOrDefault());
    }

    /// <summary>
    /// Appeler quand le niveau est réussi redirige vers le prochain niveau.
    /// </summary>
    /// <param name="niveau">The niveau terminé.</param>
    public void OnNiveauReussi(INiveauInfo niveau)
    {
        if (GetProchainNiveau(niveau) is NiveauBase nouveauNiveau)
        {
            AllerAuNiveau(nouveauNiveau);
        }
    }

    /// <summary>
    /// Gets the prochain niveau à partir du niveau terminé.
    /// </summary>
    /// <param name="niveau">The niveau terminé.</param>
    /// <returns></returns>
    private NiveauBase GetProchainNiveau(INiveauInfo niveau)
    {
        return Niveaux
            .Where(x => x.Niveau > niveau.NoNiveau)
            .FirstOrDefault();
    }

    /// <summary>
    /// Se dirigier (La balle et la caméra vers un nouveau niveau).
    /// </summary>
    /// <param name="niveau">The niveau.</param>
    private void AllerAuNiveau(NiveauBase niveau)
    {
        //Lie la balle au niveau pour compter les coups avec le bon niveau
        Balle.LierAuNiveau(niveau);

        DeplacerBallVersProchainNiveau(niveau);

        OnNiveauActuelChanger?.Invoke(niveau);
    }

    /// <summary>
    /// Deplacers the ball vers prochain niveau (se dirige avec la position de la balise de départ).
    /// </summary>
    /// <param name="niveau">The niveau.</param>
    private void DeplacerBallVersProchainNiveau(NiveauBase niveau)
    {
        //throw new NotImplementedException();
    }
}
