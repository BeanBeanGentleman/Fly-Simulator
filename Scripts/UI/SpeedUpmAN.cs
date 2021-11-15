using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpmAN : MonoBehaviour
{
    // Start is called before the first frame update
    bool in_speed_up;

    public bool get_s()
    {
        return in_speed_up;
    }
    
    public void set_speed_up()
    {
        in_speed_up = true;
    }

    public void unset_speed_up()
    {
        in_speed_up = false;
    }
}
