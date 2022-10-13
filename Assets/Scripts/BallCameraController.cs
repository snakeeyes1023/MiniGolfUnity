using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCameraController : MonoBehaviour
{

    public GameObject ball;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = ball.transform.position;

        Vector3 posGenerated = new Vector3(pos.x, transform.position.y, pos.z - 3);

        transform.position = posGenerated;
        

    }
}
