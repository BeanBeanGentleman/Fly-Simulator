using In_Level.UI;
using UnityEngine;

public class bgmStuff : MonoBehaviour
{
    public AudioSource one;

    public AudioSource two;
    private bool sww;

    private BaseObjectiveManager BOM;
    // Start is called before the first frame update
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void FixedUpdate()
    {
        if (Time.fixedTime >= 1 && !one.isPlaying)
        {
            one.Play();
        }
        if (sww)
        {
            one.volume *= 0.95f;
            two.volume = Mathf.Clamp(two.volume + 0.01f, 0, 0.5f);
            if (BOM == null)
            {
                BOM = FindObjectOfType<BaseObjectiveManager>();
                if (BOM != null)
                {
                    BOM.DontDestoryOnLoadObjects.Add(this.gameObject);
                }
                else
                {
                    Debug.LogError("CANNOT FIND BaseObjectiveManager!");
                }
            }
        }

        transform.position = Camera.main.transform.position;
    }
    
    public void Switch()
    {
        sww = true;
        
    }
}