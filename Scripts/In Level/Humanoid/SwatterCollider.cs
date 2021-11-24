using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwatterCollider : MonoBehaviour
{
    // Start is called before the first frame update
    private Collider m_collider;
    public Transform fly_object;
    public HealthBar hp_bar_manager;
    bool got_hit = false;
    void Start()
    {
        m_collider = GetComponent<Collider>();

    }

    IEnumerator SwatterDamageCoro()
    {
        yield return new WaitForSeconds(1.5f);
        got_hit = false;
    }   


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("HIT!!");
        if (other.gameObject.name == "Fly")
        {
            if (!got_hit)
            {
                float cur_hp = hp_bar_manager.getValue();
                cur_hp += -2;
                hp_bar_manager.setValueFromHit(cur_hp);
                StartCoroutine(SwatterDamageCoro());
                got_hit = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
    }
}
