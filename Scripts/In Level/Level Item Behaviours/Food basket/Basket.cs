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
        if(timer > 600)
        {
            timer = 0;
        }
        else
        {
            timer++;
        }
    }
    protected virtual void OnCollisionStay(Collision other)
    {
        BaseFlyController BFC;
        if (other.gameObject.TryGetComponent<BaseFlyController>(out BFC))
        {
            if (timer > 590)
            {
                fill_Basket(1);
            }
        }
    }
    void fill_Basket(int num)
    {
        for (int i = 0; i < num; ++i)
        {
            Vector3 pos = foodSpawnLocation + new Vector3(Random.Range(-size.x/3, size.x / 3), 5f, Random.Range(-size.z / 3, size.z / 3));
            Instantiate(foodInBasket, pos, Quaternion.identity);
        }
        
    }
}
