using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Club : MonoBehaviour
{
    // Start is called before the first frame update

    private float CurrentEnergy;

    private Vector3 _DefaultPosition;
    private Vector3 DefaultPosition
    {
        get
        {
            return new Vector3(_DefaultPosition.x, _DefaultPosition.y, _DefaultPosition.z);
        }
        set
        {
            _DefaultPosition = new Vector3(value.x, value.y, value.z);
        }
    }

    private int speed = 10;

    void Start()
    {
        CurrentEnergy = 0;
        DefaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ManageClubShoot();
        ManageClubDirectionnal();
    }

    private void ManageClubDirectionnal()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 rotationToAdd = new Vector3(2, 0, 0) * speed / 10000;
            transform.Rotate(rotationToAdd);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 rotationToAdd = new Vector3(-2, 0, 0) * speed / 10000;
            transform.Rotate(rotationToAdd);
        }
    }

    private void ManageClubShoot()
    {
        if (Input.GetKey("space"))
        {
            CurrentEnergy += 0.5f;
            RotateClub();
        }
        else if (CurrentEnergy > 0)
        {
            ThrowBall();
        }

        if (CurrentEnergy >= 100)
        {
            ResetClub();
        }
    }

    private void ThrowBall()
    {
        throw new NotImplementedException();
    }

    private void RotateClub()
    {
        Vector3 rotationToAdd = new Vector3(0, CurrentEnergy, 0) * speed / 2000;
        transform.Rotate(rotationToAdd);
    }

    private void ResetClub()
    {
        while (Input.GetKey("space"))
        {
            CurrentEnergy = 0;
            transform.SetPositionAndRotation(DefaultPosition, Quaternion.identity);
        }
    }
}
