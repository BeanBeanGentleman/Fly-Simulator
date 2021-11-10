using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeSnow : MonoBehaviour
{
    private bool inside_fridge = false;
    private bool is_counting = false;
    private int freeze_amount = 0;
    private float last_time_stamp = 0;

    public HealthBar hp_bar;
    private float[] hp_loss_amt = new float[] {0.001f, 0.001f, 0.001f, 0.002f, 0.002f};
    // Start is called before the first frame update
    void Start()
    {
        last_time_stamp = Time.time;
    }


    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.name == "Fly")
        {
            inside_fridge = true;
        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.name == "Fly")
        {
            inside_fridge = false;
        }
    }

    public int is_in_fridge()
    {
        return freeze_amount;
    }



    // Update is called once per frame
    void Update()
    {
        if (Time.time - last_time_stamp > 2)
        {
            last_time_stamp = Time.time;
            //Debug.Log(freeze_amount);
            // Update Freezeing status once every 1 second
            if (inside_fridge)
            {
                // If the fly is inside the fridge
                if (freeze_amount >= 5)
                {
                    return;
                }
                else
                {
                    freeze_amount += 1;
                }
            }
            else
            {
                // If the fly is no longer inside the fridge
                freeze_amount = 0;
            }
        }

        if (freeze_amount > 0)
        {
            float cur_hp = hp_bar.getValue();
            cur_hp -= hp_loss_amt[freeze_amount - 1];
            hp_bar.setValue(cur_hp);
        }
    }
}
