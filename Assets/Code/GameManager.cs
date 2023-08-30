using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public float Health = 3;
    private float CurrentHealth;
    public Text HealthText;

    public void DamagePlayer()
    {
        CurrentHealth--;
        Debug.Log(CurrentHealth);
        HealthText.text = "Health: " + CurrentHealth;
    }

    void Start() {
        CurrentHealth = Health;
        HealthText.text = "Health: " + CurrentHealth;
    }
    
    void Update() {
        if (Health == 0) {
            // reset player
        }
    }

}
