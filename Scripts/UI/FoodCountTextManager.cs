using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodCountTextManager : MonoBehaviour
{
    public Text text;
    public FoodCountManager food_ma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "CheeseCount")
        {
            text.text = food_ma.get_count(0).ToString();
        }
        else if (gameObject.name == "AppleCount")
        {
            text.text = food_ma.get_count(1).ToString();
        }
        else if (gameObject.name == "BananaCount")
        {
            text.text = food_ma.get_count(2).ToString();
        }

        if ((food_ma.get_count(0) + food_ma.get_count(1) + food_ma.get_count(2)) == 0)
        {
            // TODO, DISPLAY WINNING SCREEN
        }
    }
}
