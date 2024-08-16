using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;
    [SerializeField] private Transform hoursPivot;
    [SerializeField] private Transform minutesPivot;
    [SerializeField] private Transform secondsPivot;

    private void Awake()
    {
        StartCoroutine(UpdateClock());
    }

    private IEnumerator UpdateClock()
    {
        while (true)
        {
            CheckHours();
            yield return new WaitForSeconds(1f);
        }
    }

    private void CheckHours()
    {
        DateTime vietnamTime = DateTime.UtcNow.AddHours(7);

        hoursPivot.localRotation =
            Quaternion.Euler(0f, hoursToDegrees * vietnamTime.Hour, 0f);
        minutesPivot.localRotation =
            Quaternion.Euler(0f, minutesToDegrees * vietnamTime.Minute, 0f);
        secondsPivot.localRotation =
            Quaternion.Euler(0f, secondsToDegrees * vietnamTime.Second, 0f);
    }

}
