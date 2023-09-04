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
    //public Text HealthText;
    public Text WinText;
    public Text ScoreText;
    public Text LivesText;

    public GameObject HBFilled;
    public GameObject Life;
    public GameObject CollectedBread;
    public GameObject CollectedGrape;
    public GameObject CollectedPancake;
    public GameObject CollectedMetamato;

    public EventTrigger.TriggerEvent DeathTrigger;
    public string NextLevel;
    private float Score = 0f;
    public float ScoreModifier = 1f;

    private float width = 1f;
    private float fullWidth = 1f;
    public int foodCollected = 0;
    public int lives = 0;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void DamagePlayer() {
        audioManager.PlaySFX(audioManager.hit);
        CurrentHealth--;
        Debug.Log(CurrentHealth);
        width = width - fullWidth * 1/Health;
        HBFilled.transform.localScale = new Vector2(width, 0.93f);
    }

    public void LevelFinish() {
        audioManager.PlaySFX(audioManager.victory);
        WinText.enabled = true;
        SceneManager.LoadScene(sceneName: NextLevel);
    }

    void Start() {
        CurrentHealth = Health;
        CollectedBread.SetActive(false);
        CollectedPancake.SetActive(false);
        CollectedMetamato.SetActive(false);
        CollectedGrape.SetActive(false);
        Score = 0;
        //HealthText.text = "Health: " + CurrentHealth;
        WinText.enabled = false;
    }

    public void GainScore() {
        audioManager.PlaySFX(audioManager.collectable);
        ScoreModifier = 100;
        Score +=  ScoreModifier;
        ScoreText.text = " " + Score;
    }

    //When the player picks up the bread, sets the bread active in the hud.
    public void GainBread(){
        CollectedBread.SetActive(true);
        if(CurrentHealth != Health)
        {
            CurrentHealth++;
            width = width + fullWidth * 1/Health;
            HBFilled.transform.localScale = new Vector2(width, 0.93f);
        }
    }
    //When the player picks up the grape, sets the grape active in the hud.
     public void GainGrape(){
        CollectedGrape.SetActive(true);
        if(CurrentHealth != Health)
        {
            CurrentHealth++;
            width = width + fullWidth * 1/Health;
            HBFilled.transform.localScale = new Vector2(width, 0.93f);
        }
    }
    //When the player picks up the pancake, sets the pancake active in the hud.
     public void GainPancake(){
        CollectedPancake.SetActive(true);
        if(CurrentHealth != Health)
        {
            CurrentHealth++;
            width = width + fullWidth * 1/Health;
            HBFilled.transform.localScale = new Vector2(width, 0.93f);
        }
    }
    //When the player picks up the metamato, sets the metamato active in the hud.
     public void GainMetamato(){
        CollectedMetamato.SetActive(true);
        if(CurrentHealth != Health)
        {
            CurrentHealth++;
            width = width + fullWidth * 1/Health;
            HBFilled.transform.localScale = new Vector2(width, 0.93f);
        }
    }
    //When the player picks up the 1Up, adds a life to the player's total.
    public void GainLife() {
        lives += 1;
        LivesText.text = " " + lives;
    }

    void Update() {
        if (CurrentHealth <= 0) {
            if(lives <= 0) {
                audioManager.PlaySFX(audioManager.death);
                CurrentHealth = Health;
                BaseEventData EventData = new BaseEventData(EventSystem.current);
                this.DeathTrigger.Invoke(EventData);
                //HealthText.text = "Health: " + CurrentHealth;

                //Resets the healthbar and the collected foods appearing in player inventory
                width = fullWidth;
                HBFilled.transform.localScale = new Vector2(fullWidth, 0.93f);
                foodCollected = 0;
                CollectedBread.SetActive(false);
                CollectedPancake.SetActive(false);
                CollectedMetamato.SetActive(false);
                CollectedGrape.SetActive(false);
            }
            else if(lives > 0)
            {
                lives--;
                LivesText.text = " " + lives;
                width = fullWidth;
                CurrentHealth = Health;
                HBFilled.transform.localScale = new Vector2(fullWidth, 0.93f);
            }
        }
    }

}
