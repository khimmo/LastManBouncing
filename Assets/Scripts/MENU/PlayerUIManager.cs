using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUIManager : MonoBehaviour
{
    public NewBallMovementDP playerScript; 

    public Image shockwaveIcon;
    public Image controlsInvertedIcon;
    public Image shockBoostedIcon;
    public Image speedBoostedIcon;
    public Image burgerIcon;
    public TextMeshProUGUI burgerCountText;

    void Update()
    {
        
        if (playerScript != null)
        {
            
            shockwaveIcon.enabled = playerScript.hasShockwave;
            controlsInvertedIcon.enabled = playerScript.controlsInverted;
            shockBoostedIcon.enabled = playerScript.isShockBoosted;
            speedBoostedIcon.enabled = playerScript.isSpeedBoosted;
        }

        if (burgerIcon != null && burgerCountText != null)
        {
            bool hasBurgers = playerScript.burgerCount > 0;
            burgerIcon.enabled = hasBurgers;
            burgerCountText.text = hasBurgers ? playerScript.burgerCount.ToString() : "";
        }
    }
}
