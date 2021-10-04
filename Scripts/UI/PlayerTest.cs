 using System.Collections; 
 using System.Collections.Generic; 
 using UnityEngine; 
public class PlayerTest: MonoBehaviour 
{ 
    public int maxHealth = 100;
    public int total = 100;
    public int currentHealth; 
    public HealthBar healthBar; 
    // Start is called before the first frame update 
    void Start() 
    { 
        currentHealth = maxHealth; 
        healthBar.setMaxValue(maxHealth);
        StartCoroutine(Time());
    } 
    // Update is called once per frame 
    void Update() 
    { 
        if (total == 0)
        {
            Debug.Log("game over");
        }
    }
   void TakeDamage(int damage) 
    { 
        currentHealth -= damage; 
        healthBar.setValue(currentHealth); 
    }
    void Heal(int heal){
        currentHealth += heal; 
        if (currentHealth >= maxHealth){
            currentHealth = maxHealth;
        }
        healthBar.setValue(currentHealth); 
    }

    IEnumerator Time()
    {
        while (total >= 0)
        {
            TakeDamage(10);
            yield return new WaitForSeconds(1);
            total--;
        }
    }
} 
