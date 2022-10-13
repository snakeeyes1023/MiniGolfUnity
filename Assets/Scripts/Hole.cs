using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public event Action OnLevelSucess;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Ball>() is Ball ball)
        {
            OnLevelSucess?.Invoke();
        }
    }
}
