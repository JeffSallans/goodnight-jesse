using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSleeping : MonoBehaviour
{
    public Animator rabbitAnimator;

    public Animator roomAnimator;

    public int clickCount = 0;

    public bool isPlayingSong = false;

    private IEnumerator resetCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        isPlayingSong = false;
        clickCount = 0;

        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        if (clickCount > 5 && !isPlayingSong)
        {
            roomAnimator.SetTrigger("playSong");
            isPlayingSong = true;
            StartCoroutine(ResetIsPlaying());
            return;
        }

        clickCount++;

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

        if (resetCoroutine != null)
        {
            resetCoroutine = ResetCount();
            StartCoroutine(resetCoroutine);
        }
    }

    private IEnumerator ResetCount()
    {
        yield return new WaitForSeconds(3);
        clickCount = 0;
        resetCoroutine = null;
    }

    public IEnumerator ResetIsPlaying()
    {
        yield return new WaitForSeconds(55);
        clickCount = 0;
        isPlayingSong = false;
    }
}
