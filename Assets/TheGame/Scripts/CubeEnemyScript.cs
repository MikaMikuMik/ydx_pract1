using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeEnemyScript : MonoBehaviour
{
    Vector3 originalPos;
    float direction = 0.0f;
    float movYSpeed = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;

        direction = Random.Range(0.0f, 1.0f) > 0.5f ? 1.0f : -1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, movYSpeed * direction, 0.0f);

        if (transform.position.y > originalPos.y + 2.0f)
        {
            direction *= -1.0f;
        }
    }
}
