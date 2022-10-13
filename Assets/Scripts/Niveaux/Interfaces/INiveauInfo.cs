using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INiveauInfo
{
    int NoNiveau { get; }
    int GetNombreCoupSuggerer();
    int TotalCoupFaitActuel { get; }
    bool NiveauTermine { get; }
}
