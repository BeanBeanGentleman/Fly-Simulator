using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSizeChange : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 StartScale;
    float speed_s = 1f;
    void Start()
    {
        StartScale = this.transform.localScale;
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        this.transform.localScale -= new Vector3(speed_s, speed_s, speed_s);
        if (transform.localScale.x <= 70f && transform.localScale.y <= 70f && transform.localScale.z <= 70f)
        {
            speed_s = -1f;
        }
        if (transform.localScale.x >= 100f && transform.localScale.y >= 100f && transform.localScale.z >= 100f  )

        {
            speed_s = 1f;
        }

    }
}
