using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


[RequireComponent(typeof(TextMeshProUGUI))]
public class CompteurNiveauActuel : MonoBehaviour
{
    [Header("Gestionnaire de niveaux")]
    public GestionnaireNiveau GestionnaireNiveau;

    private TextMeshProUGUI etiquette;

    // Start is called before the first frame update
    void Start()
    {
        etiquette = GetComponent<TextMeshProUGUI>();

        GestionnaireNiveau.OnNiveauActuelChanger += OnChangementNiveau;
    }

    public void OnChangementNiveau(INiveauInfo niveauInfo)
    {
        etiquette.text = $"{niveauInfo.NoNiveau}";
    }
}