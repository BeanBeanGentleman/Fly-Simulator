using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public GameObject playerFly;
    public GameObject Basketinfo;
    public GameObject cheese;
    public GameObject apple;
    public GameObject banana;
    private Vector3 foodSpawnLocation;
    public Vector3 size;
    public BagCountManager bag_manager;
    public FoodCountManager count_manager;
    private int timer;
    // Start is called before the first frame update
    void Start()
    {
        size = Basketinfo.GetComponent<Collider>().bounds.size;
        foodSpawnLocation = Basketinfo.transform.position;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 600)
        {
            timer = 0;
        }
        else
        {
            timer++;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        BaseFlyController BFC;
        if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
        {
            if (timer > 594)
            {
                if(bag_manager.get_total_food_count() > 0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (bag_manager.get_bag_count(i) > 0)
                        {
                            fill_Basket(i);
                            bag_manager.decrease_food_count(i, 1);
                            break;
                        }
                    }
                }
            }
        }
        if (other.gameObject.tag == "Apple")
        {
            count_manager.decrease_food_count(1, 1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Banana")
        {
            count_manager.decrease_food_count(2, 1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Cheese")
        {
            count_manager.decrease_food_count(0, 1);
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Apple")
        {
            count_manager.decrease_food_count(1, 1);
            Destroy(other.gameObject);
        }
        if (other.tag == "Banana")
        {
            count_manager.decrease_food_count(2, 1);
            Destroy(other.gameObject);
        }
        if (other.tag == "Cheese")
        {
            count_manager.decrease_food_count(0, 1);
            Destroy(other.gameObject);
        }
    }

    void fill_Basket(int num)
    {
        Vector3 pos = foodSpawnLocation + new Vector3(Random.Range(-size.x / 4, size.x / 4), 5f, Random.Range(-size.z / 4, size.z / 4));
        if (num == 0)
        {
            GameObject myGameObject = Instantiate(cheese, pos, Quaternion.identity); 
            Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>(); 
            gameObjectsRigidBody.mass = 5;
            
        }
        else if (num == 1)
        {
            GameObject myGameObject = Instantiate(apple, pos, Quaternion.identity);
            Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>();
            gameObjectsRigidBody.mass = 5;
            
        }
        else if (num == 2)
        {
            GameObject myGameObject = Instantiate(banana, pos, Quaternion.identity);
            Rigidbody gameObjectsRigidBody = myGameObject.AddComponent<Rigidbody>();
            gameObjectsRigidBody.mass = 5;
            
        }
        

    }
}