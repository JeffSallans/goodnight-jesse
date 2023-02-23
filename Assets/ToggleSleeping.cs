using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSleeping : MonoBehaviour
{
    public Animator rabbitAnimator;

    public Animator roomAnimator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if (rabbitAnimator != null)
        {
            var isRabbitSleeping = rabbitAnimator.GetBool("isSleeping");
            rabbitAnimator.SetBool("isSleeping", !isRabbitSleeping);
        }

        if (roomAnimator != null)
        {
            var isSleeping = roomAnimator.GetBool("isSleeping");
            roomAnimator.SetBool("isSleeping", !isSleeping);
        }
    }
}
