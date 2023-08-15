using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereShadow : MonoBehaviour
{
    public float ScaleChangeSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale -= new Vector3(ScaleChangeSpeed, ScaleChangeSpeed, ScaleChangeSpeed);

        if (transform.localScale.x < 0.0f)
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
