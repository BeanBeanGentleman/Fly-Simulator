using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{   
    public Sprite[] animationImages;
    public Image animationObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animationObj.sprite = animationImages[(int) (Time.time * 30) % animationImages.Length];
    }
}
