using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour
{   
    public static bool IsPaused = false;

    public GameObject PauseMenuUI, InstructionUI;
    public GameObject Pausebutton;

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
        if (InstructionUI){
            InstructionUI.SetActive(true);
        }
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void Pause(){
        PauseMenuUI.SetActive(true);
        if (InstructionUI){
            InstructionUI.SetActive(false);
        }
        Time.timeScale = 0f;
        if (!IsPaused){
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(Pausebutton);
        }
        IsPaused = true;
    }
}
