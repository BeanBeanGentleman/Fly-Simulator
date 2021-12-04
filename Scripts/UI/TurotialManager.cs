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
    private int food_total,leftcount, rightcount, dpadcount, triggercount;
    private bool ll, lr, lu, ld, rl, rr, ru, rd, du, dd, lt, rt, speed_up;
    public float timer = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        popupIndex = 0;
        leftcount = 0;
        rightcount = 0;
        dpadcount = 0;
        triggercount = 0;
        ll = false;
        lu = false;
        lr = false;
        ld = false;
        rl = false;
        rr = false;
        ru = false;
        rd = false;
        du = false;
        dd = false;
        lt = false;
        rt = false;
        speed_up = false;
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
            timer -= Time.deltaTime;
            var lsupValue = gamepad.leftStick.up.ReadValue();
            var lsdownValue = gamepad.leftStick.down.ReadValue();
            var lsrightValue = gamepad.leftStick.right.ReadValue();
            var lsleftValue = gamepad.leftStick.left.ReadValue();
            if (lsupValue == 1 && lu == false){
                leftcount ++;
                lu = true;
            }else if (lsdownValue == 1 && ld == false){
                leftcount ++;
                ld = true;
            }else if (lsrightValue == 1 && lr == false){
                leftcount ++;
                lr = true;
            }else if (lsleftValue == 1 && ll == false){
                leftcount ++;
                ll = true;
            }
            if (leftcount == 4 || (timer < 0 && leftcount >=1)){
                popupIndex ++;
                timer = 3.0f;
            }else if (leftcount == 0){
                timer = 3.0f;
            }
        }else if (popupIndex == 1){
            timer -= Time.deltaTime;
            var rsdownValue = gamepad.rightStick.down.ReadValue();
            var rsleftValue = gamepad.rightStick.left.ReadValue();
            var rsrightValue = gamepad.rightStick.right.ReadValue();
            var rsupValue = gamepad.rightStick.up.ReadValue();
            if (rsupValue == 1 && ru == false){
                rightcount ++;
                ru = true;
            }else if (rsdownValue == 1 && rd == false){
                rightcount ++;
                rd = true;
            }else if (rsrightValue == 1 && rr == false){
                rightcount ++;
                rr = true;
            }else if (rsleftValue == 1 && rl == false){
                rightcount ++;
                rl = true;
            }
            if (rightcount == 4 || (timer <= 0 && rightcount >=1)){
                popupIndex ++;
                timer = 3.0f;
            }else if (rightcount == 0){
                timer = 3.0f;
            }        
        }else if (popupIndex == 2){
            timer -= Time.deltaTime;
            var dpadup = gamepad.dpad.up.ReadValue();
            var dpaddown = gamepad.dpad.down.ReadValue();
            if (dpadup == 1 && du == false){
                dpadcount ++;
                du = true;
            }else if (dpaddown == 1 && dd == false){
                dpadcount ++;
                dd = true;
            }
            if (dpadcount == 2 || (timer < 0 && dpadcount >= 1))
            {
                timer = 3.0f;
                popupIndex ++;
            }
        } else if (popupIndex == 3){
            timer -= Time.deltaTime;
            var lefttrigger = gamepad.leftTrigger.ReadValue();
            var righttrigger = gamepad.rightTrigger.ReadValue();
            if (lefttrigger == 1 && lt == false){
                triggercount ++;
                lt = true;
            }else if (righttrigger == 1 && rt == false){
                triggercount ++;
                rt = true;    
            }
            if (triggercount == 1 || (timer < 0 && triggercount >= 1))
            {
                popupIndex ++;
            }
        }
        else if (popupIndex == 4)
        {
            var y_pressed = gamepad.buttonNorth.ReadValue();
            if (y_pressed == 1)
            {
                popupIndex++;
            }
        }
 
        else if (popupIndex == 5){
            var food_count_current = bagcountmanager.get_bag_count(0) + bagcountmanager.get_bag_count(1) + bagcountmanager.get_bag_count(2);
            if (food_count_current >= 1){
                popupIndex ++;
            }
        }else if (popupIndex == 6){
            var food_count_current = bagcountmanager.get_bag_count(0) + bagcountmanager.get_bag_count(1) + bagcountmanager.get_bag_count(2);
            if (food_count_current == 0){
                timer = 5.0f;
                popupIndex ++;
            }
        }
        else
        {
            timer -= 0.1f;
            if (timer <= 0)
            {
                popupIndex++;
            }
        }
    }
}
