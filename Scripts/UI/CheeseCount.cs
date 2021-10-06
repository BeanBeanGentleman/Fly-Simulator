using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseCount : MonoBehaviour
{   
    public Text text;
    private int total = 100;
    public float animationTime = 1.4f;
    private float initialScore = 0;
    private float targetScore = 0;
    private float currentScore = 0;

    public void SetNumber(float value){
        initialScore = currentScore;
        targetScore = value;
    }

    public void AddToScore(float value){
        initialScore = currentScore;
        targetScore += value;
    }

    // Start is called before the first frame update
    void Start()
    {
        // SetNumber(100);
        var rn = Random.Range(10, 100);
        initialScore = rn;
        currentScore = rn;
        targetScore = rn;
        StartCoroutine(CountTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScore != targetScore){
            if (initialScore < targetScore){
                currentScore += (animationTime * Time.deltaTime) * (targetScore - initialScore);
                if (currentScore > targetScore){
                    currentScore = targetScore;
                }
            }else{
                currentScore -= (animationTime * Time.deltaTime) * (initialScore - targetScore);
                if (currentScore < targetScore){
                    currentScore = targetScore;
                }
            }
            text.text = currentScore.ToString("0.0");
        }
    }

    IEnumerator CountTime()
    {
        while (total >= 0)
        {
            AddToScore(-1);
            yield return new WaitForSeconds(1);
            total--;
        }
    }
}
