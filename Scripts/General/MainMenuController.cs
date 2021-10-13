using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] public string sceneName;

    public bool NotYet = true;
    public void Exit()
    {
        Application.Quit();
    }

    public void LoadScene()
    {
        if (NotYet)
        {
            
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}