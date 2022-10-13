using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Troue : MonoBehaviour
{
    public event Action OnBalleDansTroue;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Balle>() is Balle ball)
        {
            OnBalleDansTroue?.Invoke();
        }
    }
}
