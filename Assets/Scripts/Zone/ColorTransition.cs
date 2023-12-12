using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorTransition : MonoBehaviour
{
    [SerializeField] Material material;
    [SerializeField] ZoneShrink zoneShrink;
    [SerializeField] float point;
    [SerializeField] Color[] colors;
    [SerializeField] int colorIndex = 0;
    [SerializeField] int targetIndex = 1;
    [SerializeField] float time;



    private void Start()
    {
       // zoneShrink = FindObjectOfType<ZoneShrink>();
    }

    public void Transition()
    {
        //if (zoneShrink.timer <= 10f)
        {
            point += Time.deltaTime/time;
            material.color = Color.Lerp(colors[colorIndex], colors[targetIndex], point);
            targetIndex++;
            if (point >= 1f)
            {
                colorIndex = targetIndex;
                if (colorIndex == colors.Length)
                {
                    targetIndex = 0;
                }
            }
        }
    }

    private void Update()
    {
        Transition();
    }
}
