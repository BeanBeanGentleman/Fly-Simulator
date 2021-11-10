using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FoodCountTextManager : MonoBehaviour
{
    public Text text;
    public FoodCountManager food_ma;
    public BagCountManager bag_ma;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "CheeseCount")
        {   
            if (food_ma.get_count(0) == 0){
                text.text = "Completed";
            }else{
                text.text = food_ma.get_count(0).ToString() + " Remain / " + bag_ma.get_bag_count(0).ToString() + " in bag";
            }
        }
        else if (gameObject.name == "AppleCount")
        {   
            if (food_ma.get_count(1) == 0){
                text.text = "Completed";
            }else{
                text.text = food_ma.get_count(1).ToString()+ " Remain / " + bag_ma.get_bag_count(1).ToString() + " in bag";
            }
        }
        else if (gameObject.name == "BananaCount")
        {
            if (food_ma.get_count(2) == 0){
                text.text = "Completed";
            }else{
                text.text = food_ma.get_count(2).ToString()+ " Remain / " + bag_ma.get_bag_count(2).ToString() + " in bag";
            }
        }

        if ((food_ma.get_count(0) + food_ma.get_count(1) + food_ma.get_count(2)) == 0)
        {
            // TODO, DISPLAY WINNING SCREEN
        }
    }
}
