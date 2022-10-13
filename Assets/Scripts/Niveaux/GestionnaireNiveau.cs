using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GestionnaireNiveau : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Information générale")]
    public NiveauBase[] Niveaux;
    public Club Baton;
    public event Action<INiveauInfo> OnNiveauActuelChanger;


    void Start()
    {
        foreach (var niveau in Niveaux)
        {
            niveau.OnNiveauReussi += OnNiveauReussi;
        }
    }

    public void OnNiveauReussi(INiveauInfo niveau)
    {
        if (GetProchainNiveau(niveau) is NiveauBase nouveauNiveau)
        {
            AllerAuNiveau(nouveauNiveau);
        }
    }

    private NiveauBase GetProchainNiveau(INiveauInfo niveau)
    {
        return Niveaux
            .OrderBy(x => x.Niveau)
            .Where(x => x.Niveau > niveau.NoNiveau)
            .FirstOrDefault();
    }

    private void AllerAuNiveau(NiveauBase niveau)
    {
        OnNiveauActuelChanger?.Invoke(niveau);

        Baton.LierAuNiveau(niveau);

        DeplacerCameraVersProchainNiveau(niveau);
        DeplacerBallVersProchainNiveau(niveau);
    }

    private void DeplacerBallVersProchainNiveau(NiveauBase niveau)
    {
        throw new NotImplementedException();
    }

    private void DeplacerCameraVersProchainNiveau(NiveauBase niveau)
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
