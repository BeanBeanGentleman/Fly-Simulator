using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject playerFly;
    public GameObject foodInBasket;
    public GameObject Basketinfo;
    private Vector3 foodSpawnLocation;
    public Vector3 size;
    public FlyCarryOnFoodManager fly_car_food;
    public FoodCountManager count_manager;
    // Start is called before the first frame update
    void Start()
    {
        size = Basketinfo.GetComponent<Collider>().bounds.size;
        foodSpawnLocation = Basketinfo.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Fly")
        {
            int[] all_arr = fly_car_food.get_carry_array();
            Debug.Log(all_arr);
            for (int i = 0; i < all_arr.Length; i++)
            {
                for (int j = 0; j < all_arr[i]; j++)
                {
                    fill_Basket(1);
                }
                count_manager.decrease_food_count(i, all_arr[i]);
            }
            fly_car_food.zero_out_food_carry_array();
        }
    }

    void fill_Basket(int num)
    {
        for (int i = 0; i < num; ++i)
        {
            Vector3 pos = foodSpawnLocation + new Vector3(Random.Range(-size.x / 3, size.x / 3), 5f, Random.Range(-size.z / 3, size.z / 3));
            Instantiate(foodInBasket, pos, Quaternion.identity);
        }

    }
}