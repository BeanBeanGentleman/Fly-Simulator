using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public bool NotYet = true;
    public Animator CanvasAnimator;

    public string sceneName;
    private static readonly int UseApart = Animator.StringToHash("Use Apart");
    public void ExitOrGetUp()
    {
        if (!CanvasAnimator.GetCurrentAnimatorStateInfo(0).IsName("CANV DEFAULT"))
        {
            BroadcastMessage("ReturnToMainMenu");
            CanvasAnimator.SetBool(UseApart, false);
        }
        else
        {
            Application.Quit();
        }
    }

    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
    
}