using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpikeDamage : MonoBehaviour
{
    public EventTrigger.TriggerEvent DamageTrigger;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            Debug.Log("Hit");

            BaseEventData EventData = new BaseEventData(EventSystem.current);
            this.DamageTrigger.Invoke(EventData);
        }
    }
}
