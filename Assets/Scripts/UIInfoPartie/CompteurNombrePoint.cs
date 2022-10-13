using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class CompteurNombrePoint : MonoBehaviour
{
    private TextMeshProUGUI Etiquette;
    public GestionnaireNiveau GestionnaireNiveau;
    public Balle Balle;


    void Start()
    {
        Etiquette = GetComponent<TextMeshProUGUI>();
        Balle.OnCoupEffectuer += OnCoupFait;  
    }
    
    public void OnCoupFait(INiveauInfo niveau)
    {
        Etiquette.text = $"{(niveau.GetNombreCoupSuggerer() * -1) + niveau.TotalCoupFaitActuel}";
    }

    public void OnNouveauNiveauOuvert(INiveauInfo nouveauNiveau)
    {
        Etiquette.text = $"{nouveauNiveau.GetNombreCoupSuggerer()}";
    }
}
