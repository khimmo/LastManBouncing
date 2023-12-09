using UnityEngine;
using UnityEngine.UI;

public class PlayerUIManager : MonoBehaviour
{
    public NewBallMovementDP playerScript; 

    public Image shockwaveIcon;
    public Image controlsInvertedIcon;
    public Image shockBoostedIcon;

    void Update()
    {
        
        if (playerScript != null)
        {
            
            shockwaveIcon.enabled = playerScript.hasShockwave;
            controlsInvertedIcon.enabled = playerScript.controlsInverted;
            shockBoostedIcon.enabled = playerScript.isShockBoosted;
        }
    }
}
