using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallCameraController : MonoBehaviour
{
    public GameObject Balle;

    private Transform PositionBalle;

    private Vector3 offset;

    public float turnSpeed = 2.0f;

    public float defaultFov = 90;
    public float zoom = 25;



    void Start()
    {
        PositionBalle = Balle.transform;
        offset = new Vector3(PositionBalle.position.x - 10, PositionBalle.position.y + 7.0f, PositionBalle.position.z + 6f);
    }


    public void Update()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Horizontal") * turnSpeed, Vector3.up) * offset;
        transform.position = (PositionBalle.position + offset);

        transform.LookAt(PositionBalle.position);

        zoom += Input.mouseScrollDelta.y;

        GetComponent<Camera>().fieldOfView = defaultFov / zoom + 1;
    }
}
