using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trigger : MonoBehaviour
{
    public EventTrigger.TriggerEvent TheTrigger;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Trigger");

            BaseEventData EventData = new BaseEventData(EventSystem.current);
            this.TheTrigger.Invoke(EventData);
        }
    }
}
