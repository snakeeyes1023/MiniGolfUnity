using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    public event Action OnBallHittedByClub;

    // Start is called before the first frame update
    void Start()
    {
         m_Rigidbody = GetComponent<Rigidbody>();

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Club>() is Club club)
        {
            var contact = collision.contacts.FirstOrDefault().point;

            //m_Rigidbody.AddForce(contact.x * 2, contact.y * 2, contact.z * 2);

            OnBallHittedByClub?.Invoke();
        }
     
    }
}
