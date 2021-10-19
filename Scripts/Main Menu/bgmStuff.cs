using UnityEngine;

public class bgmStuff : MonoBehaviour
{
    public AudioSource one;

    public AudioSource two;
    private bool sww;

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
        }

        transform.position = Camera.main.transform.position;
    }

    // Update is called once per frame
    public void Switch()
    {
        sww = true;
    }
}