using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_POT : MonoBehaviour
{
    // Start is called before the first frame update

    public HealthBar hp_bar_manager;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fly")
        {
            float cur_hp = hp_bar_manager.getValue();
            cur_hp += 15;
            hp_bar_manager.setValue(cur_hp);
            Destroy(this.gameObject);
        }
    }
}
