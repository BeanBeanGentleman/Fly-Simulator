using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{   
    public GameObject mainmenu, optionsmenu, levelselectmenu, controlmenu;
    public GameObject mainbutton, levelbutton, optionsbutton, controlbutton;
    private bool mainactive, levelactive, optionactive, controlactive;
    // Start is called before the first frame update
    void Start()
    {
        mainactive = true;
        levelactive = false;
        optionactive = false;
        controlactive = false;
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

        if (optionsmenu.active){
            if (!optionactive){
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(optionsbutton);
                optionactive = true;
            }
        }else{
            optionactive = false;
        }

        if (levelselectmenu.active){
            if (!levelactive){
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(levelbutton);
                levelactive = true;
            }
        }else{
            levelactive = false;
        }

        if (controlmenu.active){
            if (!controlactive){
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(controlbutton);
                controlactive = true;
            }
        }else{
            controlactive = false;
        }
    }
}
