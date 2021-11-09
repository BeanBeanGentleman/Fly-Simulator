using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoodCountManager : MonoBehaviour
{   
<<<<<<< HEAD
=======

    public Text text;
>>>>>>> dev_tony

    private int cheese_count;
    private int banana_count;
    private int apple_count;

    private int[] food_req_count = { 3,3,3};

<<<<<<< HEAD
=======

    public int get_count(int index)
    {
        return food_req_count[index];
    }

    public void decrease_food_count(int index, int val)
    {
        food_req_count[index] -= val;
        set_food_count();
    }

    // Start is called before the first frame update
    void Start()
    {
        set_food_count();
    }   
>>>>>>> dev_tony

    public int get_count(int index)
    {
<<<<<<< HEAD
        return food_req_count[index];
=======

        food_req_count[index] = Mathf.Max(0,val);

        set_food_count();
>>>>>>> dev_tony
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
        if (food_req_count[0] == 0 && food_req_count[1] == 0 && food_req_count[2] == 0)
        {
            SceneManager.LoadScene("Win");
        }
     }
}
