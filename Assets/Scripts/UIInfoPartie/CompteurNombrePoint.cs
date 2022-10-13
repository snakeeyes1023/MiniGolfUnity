using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class CompteurNombrePoint : MonoBehaviour
{
    private TextMeshProUGUI etiquette;
    public GestionnaireNiveau GestionnaireNiveau;
    public Club baton;


    void Start()
    {
        etiquette = GetComponent<TextMeshProUGUI>();
        baton.OnCoupEffectuer += OnCoupFait;  
    }
    
    public void OnCoupFait(INiveauInfo niveau)
    {
        etiquette.text = $"{(niveau.GetNombreCoupSuggerer() * -1) + niveau.TotalCoupFaitActuel}";
    }

    public void OnNouveauNiveauOuvert(INiveauInfo nouveauNiveau)
    {
        etiquette.text = $"{nouveauNiveau.GetNombreCoupSuggerer()}";
    }
}
