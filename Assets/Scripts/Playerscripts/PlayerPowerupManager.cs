using UnityEngine;
using System.Collections;

public class PlayerPowerupManager : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2,
        PLayer3,
        Player4
    }

    public PlayerNumber playerNumber;
    public float etherealDuration = 2f;
    public bool isEtherealActive;

    public bool hasEtherealPowerup = false;
    private int originalLayer;
    public MeshRenderer meshRenderer;
    

    void Start()
    {
        originalLayer = gameObject.layer;
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        //string etherealActivationButton = playerNumber == PlayerNumber.Player1 ? "Fire3_P1" : "Fire3_P2"; //I LOVE THIS NOTATION
        string etherealActivationButton = "Fire3_" + playerNumber.ToString();
        if (hasEtherealPowerup && Input.GetButtonDown(etherealActivationButton))
        {
            StartCoroutine(ActivateEthereal());
            hasEtherealPowerup = false;
            meshRenderer.enabled = false;

        }
    }

    private IEnumerator ActivateEthereal()
    {
        isEtherealActive = true;
        ChangeLayerToEthereal();
        Debug.Log("Ethereal Active");
        

        yield return new WaitForSeconds(etherealDuration);

        RestoreOriginalLayer();
        isEtherealActive = false;
        meshRenderer.enabled = true;
        Debug.Log("Ehereal Inactive");
    }

    private void ChangeLayerToEthereal()
    {
        // Set to a layer that does not collide with the other player
        //gameObject.layer = LayerMask.NameToLayer(playerNumber == PlayerNumber.Player1 ? "Player2" : "Player1");
        gameObject.layer = LayerMask.NameToLayer("Ethereal");
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
