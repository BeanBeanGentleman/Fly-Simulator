using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class TurotialManager : MonoBehaviour
{   
    public GameObject[] popUps;
    private int popupIndex;
    public BagCountManager bagcountmanager;
    private int food_total;

    // Start is called before the first frame update
    void Start()
    {
        popupIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        for (int i = 0; i < popUps.Length; i++){
            if (i == popupIndex){
                popUps[i].SetActive(true);
            }else{
                popUps[i].SetActive(false);
            }
        }
        if (popupIndex == 0){
            var lsupValue = gamepad.leftStick.up.ReadValue();
            if (lsupValue == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 1){
            var lsdownValue = gamepad.leftStick.down.ReadValue();
            if (lsdownValue == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 2){
            var lsleftValue = gamepad.leftStick.left.ReadValue();
            if (lsleftValue == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 3){
            var lsrightValue = gamepad.leftStick.right.ReadValue();
            if (lsrightValue == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 4){
            var rsupValue = gamepad.rightStick.up.ReadValue();
            if (rsupValue == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 5){
            var rsdownValue = gamepad.rightStick.down.ReadValue();
            if (rsdownValue == 1){
                popupIndex ++;
            }           
        }else if (popupIndex == 6){
            var rsleftValue = gamepad.rightStick.left.ReadValue();
            if (rsleftValue == 1){
                popupIndex ++;
            }  
        }else if (popupIndex == 7){
            var rsrightValue = gamepad.rightStick.right.ReadValue();
            if (rsrightValue == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 8){
            var dpadup = gamepad.dpad.up.ReadValue();
            if (dpadup == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 9){
            var dpaddown = gamepad.dpad.down.ReadValue();
            if (dpaddown == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 10){
            var lefttrigger = gamepad.leftTrigger.ReadValue();
            if (lefttrigger == 1){
                popupIndex ++;
            }           
        }else if (popupIndex == 11){
            var righttrigger = gamepad.rightTrigger.ReadValue();
            if (righttrigger == 1){
                popupIndex ++;
            }
        }else if (popupIndex == 12){
            var food_count_current = bagcountmanager.get_bag_count(0) + bagcountmanager.get_bag_count(1) + bagcountmanager.get_bag_count(2);
            if (food_count_current >= 1){
                popupIndex ++;
            }
        }
    }
}
