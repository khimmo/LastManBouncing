using UnityEngine;
using System.Collections;

public class PlayerPowerupManager : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2
    }

    public PlayerNumber playerNumber;
    public float etherealDuration = 2f;
    public bool isEtherealActive;

    private bool hasEtherealPowerup = false;
    private int originalLayer;

    void Start()
    {
        originalLayer = gameObject.layer;
    }

    void Update()
    {
        string etherealActivationButton = playerNumber == PlayerNumber.Player1 ? "Fire3_P1" : "Fire3_P2";

        if (hasEtherealPowerup && Input.GetButtonDown(etherealActivationButton))
        {
            StartCoroutine(ActivateEthereal());
            hasEtherealPowerup = false;
        }
    }

    private IEnumerator ActivateEthereal()
    {
        isEtherealActive = true;
        ChangeLayerToEthereal();

        yield return new WaitForSeconds(etherealDuration);

        RestoreOriginalLayer();
        isEtherealActive = false;
    }

    private void ChangeLayerToEthereal()
    {
        // Set to a layer that does not collide with the other player
        gameObject.layer = LayerMask.NameToLayer(playerNumber == PlayerNumber.Player1 ? "Player2" : "Player1");
    }

    private void RestoreOriginalLayer()
    {
        gameObject.layer = originalLayer;
    }

    public void CollectEtherealPowerup()
    {
        hasEtherealPowerup = true;
    }
}
