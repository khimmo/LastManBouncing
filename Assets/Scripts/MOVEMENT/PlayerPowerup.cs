using UnityEngine;

public class PlayerPowerup : MonoBehaviour
{
    public enum PlayerNumber
    {
        Player1,
        Player2
    }

    public PlayerNumber playerNumber; 

    private EtherealPowerup etherealPowerup;

    void Update()
    {
        string activateButton = playerNumber == PlayerNumber.Player1 ? "Fire3_P1" : "Fire3_P2";

        if (Input.GetButtonDown(activateButton) && etherealPowerup != null)
        {
            etherealPowerup.ActivateEthereal(GetComponent<Collider>());
            etherealPowerup = null; // Clear the powerup after use
        }
    }

    public void SetEtherealPowerup(EtherealPowerup powerup)
    {
        etherealPowerup = powerup;
    }
}
