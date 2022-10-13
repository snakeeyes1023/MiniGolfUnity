using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Club : MonoBehaviour
{
    public INiveauInfo NiveauLier { get; private set; }

    public event Action<INiveauInfo> OnCoupEffectuer;
    public void LierAuNiveau(INiveauInfo niveau)
    {
        NiveauLier = niveau;
    }


    private float CurrentEnergy;
    private int speed = 10;
    private Vector3 DefaultPosition;
    private bool currentlyShoot;

    void Start()
    {
        CurrentEnergy = 0;
        DefaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ManageClubShoot();

        if (IsDirectionnalKeyPressed())
        {
            ManageClubDirectionnal();
        }
    }

    private void ManageClubDirectionnal()
    {
        Vector3 rotationToAdd = Vector3.zero;

        rotationToAdd += Input.GetKey(KeyCode.LeftArrow) ? Vector3.up : Vector3.zero;
        rotationToAdd += Input.GetKey(KeyCode.RightArrow) ? Vector3.down : Vector3.zero;

        transform.Rotate(rotationToAdd * speed / 100);
    }

    private bool IsDirectionnalKeyPressed()
    {
        return Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
    }

    private void ManageClubShoot()
    {
        if (Input.GetKey("space"))
        {
            currentlyShoot = true;
            RotateClub();
        }
        else if (CurrentEnergy < 500 && currentlyShoot)
        {
            ThrowBall();
        }
        else if (CurrentEnergy > 0)
        {
            currentlyShoot = false;
            RotateClub(reverse: true);
        }
        else
        {
            CurrentEnergy = 0;
            currentlyShoot=false;
        }
    }

    private void ThrowBall()
    {
        OnCoupEffectuer?.Invoke(NiveauLier);

        if (CurrentEnergy > -400)
        {
            RotateClub(reverse : true);
        }
    }

    private void RotateClub(bool reverse = false)
    {
        CurrentEnergy += reverse ? -4f : 0.5f;
        Vector3 directionnal = (reverse ? Vector3.right * 8 : Vector3.left) * speed / 100;
        transform.Rotate(directionnal);
    }
}
