using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveFlame : MonoBehaviour
{
    // Start is called before the first frame update

    private bool fly_in_col_range = false;
    private bool fire_on = true;
    private bool is_displaying = false;

    private ParticleSystem parent_particle_sys;

    void Start()
    {
        fly_in_col_range = false;
        parent_particle_sys = GetComponent<ParticleSystem>();
    }

    void hurt_fly()
    {
        if (fly_in_col_range)
        {
            // If its firing
            if (fire_on)
            {
                Debug.Log("SET FLY ON FLAME");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fly")
        {
            fly_in_col_range = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "Fly")
        {
            Debug.Log("Fly Out");
        }
    }

    void fly_leave_fire()
    {
        fly_in_col_range = false;
    }

    IEnumerator FireControlCoroutine()
    {
        is_displaying = !is_displaying;
        if (fire_on)
        {
            // Fire for 10 secons
            yield return new WaitForSeconds(10);
        }
        else
        {
            yield return new WaitForSeconds(6);
        }
        fire_on = !fire_on;
    }
        

    void fire_flame()
    {
        Debug.Log(fire_on);
        if (fire_on && !is_displaying)
        {
            parent_particle_sys.Clear();
            parent_particle_sys.Play();
            StartCoroutine(FireControlCoroutine());
        }
        else if (!fire_on && is_displaying)
        {
            parent_particle_sys.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            if (is_displaying)
            {
                StartCoroutine(FireControlCoroutine());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        fire_flame();
        hurt_fly();
    }
}
