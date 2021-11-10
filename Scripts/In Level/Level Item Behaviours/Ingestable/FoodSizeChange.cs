using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSizeChange : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 StartScale;
    float speed_s = 0.1f;
    void Start()
    {
        StartScale = this.transform.localScale;
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        this.transform.localScale -= new Vector3(speed_s, speed_s, speed_s);
        if (transform.localScale.x <= 7f && transform.localScale.y <= 7f && transform.localScale.z <= 7f)
        {
            speed_s = -0.1f; 
        }
        if (transform.localScale.x >= 15f && transform.localScale.y >= 15f && transform.localScale.z >= 15f)

        {
            speed_s = 0.1f; 
        }

    }
}
