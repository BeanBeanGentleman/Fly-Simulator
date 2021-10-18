using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAlertScript : MonoBehaviour
{
    public GameObject target;
    Rect rect = new Rect(0, 0, 300, 100);
    Vector3 offset = new Vector3(0f, 0f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        onGUI();
    }

    private void onGUI()
    {
        Vector3 point = Camera.main.WorldToScreenPoint(target.transform.position + offset);
        rect.x = point.x;
        rect.y = Screen.height - point.y - rect.height; // bottom left corner set to the 3D point
        GUI.Label(rect, target.name); // display its name, or other string
    }
}
