using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingPlayer : MonoBehaviour
{
    public Transform player;

    private Vector3 playerDistFromAI;
    private Color color = Color.yellow;

    public float velocity = 7.0f;
    public float visionRange = 50.0f;
    public float rangeFOV = 30.0f;

    private float distanceToPlayer = 0.0f;
    private float angle = 0.0f;

    private bool isWatching;

    // Update is called once per frame
    void Update()
    {
        isWatching = false;

        //  Cuadratic distance calculations.
        distanceToPlayer = Vector3.SqrMagnitude(transform.position - player.position);

        //  Condition where we evaluate if the player is in the AI field of view.
        if (distanceToPlayer <= Mathf.Pow(rangeFOV, 2))
        {
            //  Draws a line if the player is in range.
            Debug.DrawLine(transform.position, player.position, color);

            //  Vector from AI to player.
            playerDistFromAI = player.position - transform.position;

            //  Angle Calculation.
            angle = Vector3.Angle(transform.forward, playerDistFromAI);

            //  Condition that verifies if the player is in range.
            if (angle <= rangeFOV)
            {
                //  Line of angle detection.
                Debug.DrawLine(transform.position, player.position, Color.white, 100.0f);
                isWatching = true;
            }
        }

        if (isWatching)
        {
            Debug.Log("Player is being watched");

            //  Some code or behaviour.
        }
        else
        {
            Debug.Log("Player is not being watched");
        }
    }
}
