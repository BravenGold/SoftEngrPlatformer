using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public float Health = 3;
    private float CurrentHealth;
    public Text HealthText;
    public Text WinText;
    public Text ScoreText;
    public EventTrigger.TriggerEvent DeathTrigger;
    private float Score = 0f;
    public float ScoreModifier = 1f;
    public string NextLevel;

    public void DamagePlayer()
    {
        CurrentHealth--;
        Debug.Log(CurrentHealth);
        HealthText.text = "Health: " + CurrentHealth;
    }

    public void LevelFinish() {
        WinText.enabled = true;
        SceneManager.LoadScene(sceneName: NextLevel);
    }

    void Start() {
        CurrentHealth = Health;
        Score = 0;
        HealthText.text = "Health: " + CurrentHealth;
        WinText.enabled = false;
    }

    public void GainScore() {
        Score += ScoreModifier;
        ScoreText.text = "Score: " + Score;
    }

    void Update() {
        if (CurrentHealth <= 0) {
            CurrentHealth = Health;
            BaseEventData EventData = new BaseEventData(EventSystem.current);
            this.DeathTrigger.Invoke(EventData);
            HealthText.text = "Health: " + CurrentHealth;

        }
    }

}
