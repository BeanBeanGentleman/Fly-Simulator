using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCarryOnFoodManager : MonoBehaviour
{
    // Start is called before the first frame update
    // Apple, Banana, Cheese
    private int[] carry_array = { 2, 2, 2 };

    void Start()
    {
        
    }
    
    void increment_food_carry_array(int index, int val)
    {
        carry_array[index] += val;
    }

    void decrement_food_carry_array(int index, int val)
    {
        carry_array[index] -= val;
    }

    public void zero_out_food_carry_array()
    {
        for (int i = 0; i < 3; i++)
        {
            carry_array[i] = 0;
        }
    }

    public int[] get_carry_array()
    {
        return carry_array;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
