using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CoinsScore : MonoBehaviour
{
    public EventTrigger.TriggerEvent ScoreTrigger;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Score");

            BaseEventData EventData = new BaseEventData(EventSystem.current);
            this.ScoreTrigger.Invoke(EventData);
            Destroy(this.gameObject);
        }
    }
}
