using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interception : MonoBehaviour
{
    public GameObject player;
    public GameObject prediction;

    //  Player movement vector variables.
    private Vector3 relativeVel;
    private Vector3 aiVel;
    private Vector3 playerVel;
    private Vector3 aiPreviousPos;
    private Vector3 playerPreviousPos;
    private Vector3 relativeDist;
    private Vector3 futurePos;
    private Vector3 predictionPos;

    private float interceptionTime;

    public float velocity = 5;
    // Start is called before the first frame update
    void Start()
    {
        aiPreviousPos = transform.position;
        playerPreviousPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //  AI velocity vector calculation.
        aiVel = (transform.position - aiPreviousPos) / Time.deltaTime;
        aiPreviousPos = transform.position;

        //  Player velocity vector calculation.
        playerVel = (player.transform.position - playerPreviousPos) / Time.deltaTime;
        playerPreviousPos = player.transform.position;

        //  Relative velocity between ai and player.
        relativeVel = playerVel - aiVel;

        //  Relative distance calculation.
        relativeDist = player.transform.position - transform.position;

        //  Interception time calculation.
        interceptionTime = relativeDist.magnitude / relativeVel.magnitude;

        //  Prediction of player position.
        futurePos = player.transform.position + (playerVel * interceptionTime);

        predictionPos = new Vector3(futurePos.x, transform.position.y, futurePos.z);

        transform.LookAt(predictionPos);
        prediction.transform.position = predictionPos;

        //  Move towards the player.
        transform.Translate(Vector3.forward * velocity * Time.deltaTime);
    }
}
