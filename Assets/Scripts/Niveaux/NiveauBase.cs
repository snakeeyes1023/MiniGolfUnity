using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NiveauBase : MonoBehaviour, INiveauInfo
{

    #region Unity props

    [Header("Troue du niveau")]
    public MonoBehaviour Troue;

    [Header("Information du niveau")]
    public int Par;
    public string Nom;
    public int Niveau;

    #endregion

    public int TotalCoupFaitActuel { get; private set; }
    public bool NiveauTermine { get; private set; }
    public int NoNiveau { get { return Niveau; }  }

    #region Event

    public event Action<INiveauInfo> OnNiveauReussi;

    #endregion

    #region Built IN

    public void Awake()
    {
        if (Troue is Troue troue)
        {
            troue.OnBalleDansTroue += NiveauTerminer;
        }
    }

    #endregion

    /// <summary>
    /// Niveaus the terminer.
    /// </summary>
    public void NiveauTerminer()
    {
        NiveauTermine = true;
        OnNiveauReussi?.Invoke(this);
    }

    /// <summary>
    /// Gets the nombre coup suggerer (PAR).
    /// </summary>
    /// <returns></returns>
    public int GetNombreCoupSuggerer()
    {
        return Par;
    }

    /// <summary>
    /// Ajouter un coup au niveau.
    /// </summary>
    public void AjouterUnCoup()
    {
        TotalCoupFaitActuel++;
    }
}