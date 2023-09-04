using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    public float MoveSpeed;
    public Transform GroundDetection;
    public GameObject Player;
    public float AttackRange;

    private bool MovingRight = true;
    private float Distance;

    void Update()
    {
        Distance = Vector2.Distance(this.transform.position, Player.transform.position);
        //Debug.Log(Distance);

        RaycastHit2D groundInfo = Physics2D.Raycast(GroundDetection.position, Vector2.down, 2f);

        if ((float)Distance <= AttackRange)
        {
            Vector2 direction = Player.transform.position - this.transform.position;
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * MoveSpeed * Time.deltaTime);
            if (groundInfo.collider == false)
            {
                //Debug.Log("No Ground");
                if (MovingRight == true)
                {
                    //Debug.Log("Moving Left");
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    MovingRight = false;
                }
                else
                {
                    //Debug.Log("Moving Right");
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    MovingRight = true;
                }
            }
        }
    }
}