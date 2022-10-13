using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Balle : MonoBehaviour
{
    #region Settings

    public float Puissance;
    public BallCameraController BallCameraController;

    #endregion

    #region Events

    public event Action<INiveauInfo> OnCoupEffectuer;

    #endregion


    private Rigidbody RigidBody;
    private INiveauInfo NiveauLier;

    void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (BallCameraController.GetComponent<Camera>() is Camera camera)
        {
            RigidBody.AddForce(camera.transform.forward * Puissance, ForceMode.Impulse);

            NiveauLier.AjouterUnCoup();

            OnCoupEffectuer?.Invoke(NiveauLier);
        }
    }

    /// <summary>
    /// Liers la balle au niveau.
    /// </summary>
    /// <param name="niveau">The niveau.</param>
    public void LierAuNiveau(INiveauInfo niveau)
    {
        NiveauLier = niveau;
    }
}
