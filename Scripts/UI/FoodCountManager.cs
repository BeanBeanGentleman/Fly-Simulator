using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FoodCountManager : MonoBehaviour
{   

    public Text text;

    private int cheese_count;
    private int banana_count;
    private int apple_count;

    private int[] food_req_count = { 10, 10, 10 };


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

    public void adjust_food_count(int index, int val)
    {

        food_req_count[index] = Mathf.Max(0,val);

        set_food_count();
    }

    void set_food_count()
    {
        cheese_count = food_req_count[0];
        banana_count = food_req_count[1];
        apple_count = food_req_count[2];
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "CheeseCount")
        {
            text.text = cheese_count.ToString();
        }
        else if (gameObject.name == "AppleCount")
        {
            text.text = apple_count.ToString();
        }
        else if (gameObject.name == "BananaCount")
        {
            text.text = banana_count.ToString();
        }

        if ((cheese_count + banana_count + apple_count) == 0)
        {
            // TODO, DISPLAY WINNING SCREEN
            SceneManager.LoadScene("Win");
        }


    }
}
