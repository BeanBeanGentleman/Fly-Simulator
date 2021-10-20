using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoodCountManager : MonoBehaviour
{   

    private int cheese_count;
    private int banana_count;
    private int apple_count;

    private int[] food_req_count = { 3,3,3 };


    public int get_count(int index)
    {
        return food_req_count[index];
    }

    public void decrease_food_count(int index, int val)
    {
        food_req_count[index] = Mathf.Max(0 , food_req_count[index] - val);
    }

    // Start is called before the first frame update
    void Start()
    {
    }  

    // Update is called once per frame
    void Update()
    {

    }
}
