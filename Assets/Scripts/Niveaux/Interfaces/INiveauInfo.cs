using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INiveauInfo
{
    #region Props
    int NoNiveau { get; }
    int TotalCoupFaitActuel { get; }
    bool NiveauTermine { get; }
    #endregion

    #region Methods
    void AjouterUnCoup();
    int GetNombreCoupSuggerer();
    #endregion
}
