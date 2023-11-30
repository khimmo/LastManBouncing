using UnityEngine;
using System.Collections;

public class PlayerPowerups : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2,
        Player3,
        Player4
    }

    public PlayerNumber playerNumber;

    // Power-up related fields
    public bool isBounceBoosted = false;
    public bool isShockBoosted = false;
    public bool hasShockwave = false;
    public GameObject shockwaveExplosionPrefab;
    public float shockwaveForce;
    public float shockwaveRadius;

    // Ethereal power-up fields
    public float etherealDuration = 1f;
    public bool isEtherealActive;
    private bool hasEtherealPowerup = false;
    private int originalLayer;

    // Timers and durations for power-ups
    private float currentBounceTransitionTime = 0f;
    private float currentShockTransitionTime = 0f;
    private float bounceBoostEndTime;
    private float shockBoostEndTime;
    private float bounceBoostDuration = 0.5f;
    private float shockBoostDuration = 0.75f;

    private MovementDPMP movementScript;

    void Start()
    {
        originalLayer = gameObject.layer; // Store the original layer
        movementScript = GetComponent<MovementDPMP>(); // Reference to the movement script
    
    }

    void Update()
    {
        // Handle ethereal power-up activation
        string etherealActivationButton = GetEtherealActivationButton();
        if (hasEtherealPowerup && Input.GetButtonDown(etherealActivationButton))
        {
            StartCoroutine(ActivateEthereal());
            hasEtherealPowerup = false;
        }
    }

    private string GetEtherealActivationButton()
    {
        // Determine the correct button based on the player number
        switch (playerNumber)
        {
            case PlayerNumber.Player1:
                return "Fire3_P1";
            case PlayerNumber.Player2:
                return "Fire3_P2";
            case PlayerNumber.Player3:
                return "Fire3_P3";
            case PlayerNumber.Player4:
                return "Fire3_P4";
            default:
                return "";
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
