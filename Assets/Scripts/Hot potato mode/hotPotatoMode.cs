using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotPotatoMode : MonoBehaviour
{
    public List<GameObject> players = new List<GameObject>();
    private int playerIndex;
    private int Timers;

    public void PlayerPicker()
    {
        playerIndex = Random.Range(0, players.Count);
        AssignTag();
    }

    public void OnEnable()
    {
        PlayerPicker();
        BomBBlast();
    }

    public void AssignTag()
    {
        players[playerIndex].gameObject.GetComponent<testMovementScript>().istagged = true;
        StartCoroutine(timer() );
    }

    IEnumerator timer()
    {
        Timers += 1;
        yield return new WaitForSeconds(1);
        if (Timers >= 40)
        {
           
        }
        else
        {
            StartCoroutine(timer());
        }
    }

    public void BomBBlast()
    {
        foreach(var i in players)
        {
            if (i.GetComponent<testMovementScript>().istagged == true)
            {
                Debug.Log("player is done" + i);
                i.GetComponent<Animator>().enabled = true;
            }

            if (i.GetComponent<testMovementScript>().istagged == false)
            {
                i.GetComponent<Animator>().enabled = false;
            }
        }
    }
    private void Update()
    {
        BomBBlast();
    }
}
