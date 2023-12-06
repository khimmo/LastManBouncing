using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slowdownpowerup : MonoBehaviour
{
    [SerializeField] player2Movement player2Movement;
    [SerializeField] NewBallMovementDP newBallMovementDP;

    private void Start()
    {
        player2Movement = FindObjectOfType<player2Movement>();
        newBallMovementDP = FindObjectOfType<NewBallMovementDP>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            print("collided");
            StartCoroutine(SlowDown_Player1());
        }

        if (other.gameObject.CompareTag("Player 2"))
        {
            StartCoroutine(SlowDown_Player2());
        }
    }

    IEnumerator SlowDown_Player1()
    {
        player2Movement.maxSpeed = 4.5f;
        yield return new WaitForSeconds(10);
        player2Movement.maxSpeed = 9;
    }

    IEnumerator SlowDown_Player2()
    {
        newBallMovementDP.maxSpeed = 4.5f;
        yield return new WaitForSeconds(10);
        newBallMovementDP.maxSpeed = 9;
    }
}
