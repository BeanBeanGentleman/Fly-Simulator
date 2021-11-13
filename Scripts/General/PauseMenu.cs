using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{   
    public static bool IsPaused = false;

    public GameObject PauseMenuUI;

    private bool pressed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var gamepad = Gamepad.current;
        gamepad.startButton.pressPoint = 1;
        if (gamepad.startButton.isPressed || (gamepad.buttonEast.isPressed && IsPaused)){
            pressed = true;
        }else{
            if (pressed){
                pressed = false;
                if (IsPaused){
                    Resume();
                }else{
                    Pause();
                }
            }

        }
    }

    public void Resume(){
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
