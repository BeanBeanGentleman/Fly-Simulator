using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{

    BaseFlyController bfc_controller;
    // Start is called before the first frame update
    void Start()
    {
        bfc_controller = GameObject.FindObjectOfType<BaseFlyController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fly")
        {
            Destroy(this.gameObject);
            bfc_controller.speed_up_fly();
        }
    }
}
