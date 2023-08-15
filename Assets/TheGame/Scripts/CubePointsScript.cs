using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePointsScript : MonoBehaviour
{
    GameObject playerSphere;

    // Start is called before the first frame update
    void Start()
    {
        playerSphere = GameObject.FindObjectOfType<SphereScript>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = playerSphere.transform.position;

        float transX = 0, transY = 0;
        float transAmount = 0.01f;

        if (transform.position.x < playerPos.x)
        {
            transX = transAmount;
        }
        else
        {
            transX = transAmount * -1;
        }

        if (transform.position.y < playerPos.y)
        {
            transY = transAmount;
        }
        else
        {
            transY = transAmount * -1;
        }

        if (Vector3.Distance(playerSphere.transform.position, transform.position) <= 5)
        {
            transform.Translate(transX, transY, 0.0f);
        }
    }
}
