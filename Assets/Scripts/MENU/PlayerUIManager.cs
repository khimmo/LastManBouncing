using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public NewBallMovementDP playerScript;
    public PlayerPowerupManager powerupScript;
    public Image shockwaveIcon;
    public Image controlsInvertedIcon;
    public Image shockBoostedIcon;
    public Image speedBoostedIcon;
    public Image burgerIcon;
    public TextMeshProUGUI burgerCountText;
    public Image etherealBuffIcon;    //BEFORE
    public Image etherealActiveIcon;  //AFTER
    public Image etherealBuffChildIcon; //button guide for the ethereal buff
    public Image shockwaveChildIcon; //Circle guide for the bomb thing

    void Update()
    {
        
        if (playerScript != null)
        {
            
            shockwaveIcon.enabled = playerScript.hasShockwave;
            shockwaveChildIcon.enabled = playerScript.hasShockwave;
            controlsInvertedIcon.enabled = playerScript.controlsInverted;
            shockBoostedIcon.enabled = playerScript.isShockBoosted;
            speedBoostedIcon.enabled = playerScript.isSpeedBoosted;
        }
        
        if (powerupScript != null)
        {
            etherealBuffIcon.enabled = powerupScript.hasEtherealPowerup;
            etherealActiveIcon.enabled = powerupScript.isEtherealActive;
            etherealBuffChildIcon.enabled = powerupScript.hasEtherealPowerup;
        }
        if (burgerIcon != null && burgerCountText != null)
        {
            bool hasBurgers = playerScript.burgerCount > 0;
            burgerIcon.enabled = hasBurgers;
            burgerCountText.text = hasBurgers ? playerScript.burgerCount.ToString() : "";
        }
    }

        
    
}
