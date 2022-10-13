using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Troue : MonoBehaviour
{
    public event Action OnBallEnter;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Ball>() is Ball ball)
        {
            OnBallEnter?.Invoke();
        }
    }
}
