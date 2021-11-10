using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagCountManager : MonoBehaviour
{

    private int[] food_bag_count = {0,0,0};

    private bool in_speed_up = false;

    public int get_bag_count(int index)
    {
        return food_bag_count[index];
    }

    public bool check_if_in_speed_up()
    {
        return in_speed_up;
    }

    public void alter_speed_up()
    {
        in_speed_up = !in_speed_up;
    }

    public int get_total_food_count()
    {
        return food_bag_count[0] + food_bag_count[1] + food_bag_count[2];
    }

    public void decrease_food_count(int index, int val)
    {
        food_bag_count[index] = Mathf.Max(0 , food_bag_count[index] - val);
    }

    public void increase_food_count(int index){
        food_bag_count[index] ++;
    }

    public void clear_bag(){
        for (int i = 0; i < food_bag_count.Length; i++){
            food_bag_count[i] = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }  

    // Update is called once per frame
    void Update()
    {
        if (food_bag_count[0] == 0 && food_bag_count[1] == 0 && food_bag_count[2] == 0)
        {
            // SceneManager.LoadScene("Win");
        }
     }
}
