using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum states
{
    Patrol,
    Follow,
    Run
}
public class FSM : MonoBehaviour
{
    public Transform player;
    //  Where will the A.I. be next.
    private Vector3 objective;
    private Vector3 playerFromAI;

    private List<Vector3> route = new List<Vector3>();

    private int state = (int)states.Patrol;
    private int numbOfSteps;
    private int index = 0;

    public float velocity = 5;
    public float visionTange = 25;
    public float fovRange = 30;
    private float distToPlayer = 0;
    private float angle = 0;


    // Start is called before the first frame update
    void Start()
    {
        //  Route to patrol.
        route.Add(new Vector3(-10, 0.5f, 10));
        route.Add(new Vector3(0, 0.5f, 3));
        route.Add(new Vector3(45, 0.5f, -30));
        route.Add(new Vector3(-25, 0.5f, -17));

        index = 0;

        objective = route[index];
        numbOfSteps = route.Count;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(state);
        if (state == (int)states.Patrol)
        {
            velocity = 5;

            //  Verify if we have arrived to the route.
            if ((transform.position - route[index]).magnitude < 1)
            {
                index++;

                if (index >= numbOfSteps)
                {
                    index = 0;
                }

                objective = route[index];
            }

            transform.LookAt(objective);
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);

            //  Verify if transition is neccesary.
            if (IsWatchingPlayer() == true)
            {
                state = (int)states.Follow;
            }
        }

        else if (state == (int)states.Follow)
        {
            velocity = 10;
            transform.LookAt(player.position);

            //  Moves towards the objective.
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);

            //  Verify if there's a transition.
            if ((transform.position - player.position).magnitude < 1)
            {
                state = (int)states.Run;
            }
        }

        else if (state == (int)states.Run)
        {
            velocity = 15;

            Vector3 point = player.position - transform.position;
            Vector3 vision = transform.position - point;

            vision.y = player.position.y;

            transform.LookAt(vision);

            //  Move towards the vision.
            transform.Translate(Vector3.forward * velocity * Time.deltaTime);

            //  Verify if there's a transition.
            if ((transform.position - player.position).magnitude > 50)
            {
                state = (int)states.Patrol;
            }

            if (UnityEngine.Random.Range(1, 100) == 5 && (transform.position - player.position).magnitude > 10 )
            {
                state = (int)states.Follow;
            }
        }
    }

    public bool IsWatchingPlayer()
    {
        bool isWatching = false;

        //  Cuadratic distance calculation.
        distToPlayer = Vector3.SqrMagnitude(transform.position - player.position);

        //  verify if player is in ROV.
        if (distToPlayer <= (fovRange *  fovRange))
        {
            //  AI to player vector.
            playerFromAI = player.position - transform.position;

            //  Calculate the angle.
            angle = Vector3.Angle(transform.forward, playerFromAI);

            //  Verify if player is in FOV.
            if (angle <= fovRange)
            {
                isWatching = true;
            }

        }

        return isWatching;
    }
}
