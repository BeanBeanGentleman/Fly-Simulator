using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameOverMenu : MonoBehaviour
{
    public GameObject mainmenu, restartmenu;
    public GameObject mainbutton, restartbutton;
    private bool mainactive, restartactive;
    // Start is called before the first frame update
    void Start()
    {
        mainactive = true;
        restartactive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mainmenu.active){
            if (!mainactive){
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(mainbutton);
                mainactive = true;
            }
        }else{
            mainactive = false;
        }

        if (restartmenu.active){
            if (!restartactive){
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(restartbutton);
                restartactive = true;
            }
        }else{
            restartactive = false;
        }
    }
}
