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

    [Header("Nom du niveau")]
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

    void Start()
    {
        if (Troue is Troue hole)
        {
            hole.OnBallEnter += NiveauTerminer;
        }
    }

    #endregion

    public void NiveauTerminer()
    {
        NiveauTermine = true;
        OnNiveauReussi?.Invoke(this);
    }

    public int GetNombreCoupSuggerer()
    {
        return Par;
    }
}