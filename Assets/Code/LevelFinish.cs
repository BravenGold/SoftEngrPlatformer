using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelFinish : MonoBehaviour
{
    public EventTrigger.TriggerEvent FinishTrigger;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Finish");

            BaseEventData EventData = new BaseEventData(EventSystem.current);
            this.FinishTrigger.Invoke(EventData);
        }
    }
}
