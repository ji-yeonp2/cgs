using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    [SerializeField] private float secondPerRealTime = 1000; // 1sec om real time = 1000sec in scene

    private bool isNight=false;

    private float nightFogDensity = (float)0.1;
    private float dayFogDensity;

    private float fogDensityRate = (float)0.2; //density rate for fog increasement
    private float currentFogDensity;

    void Start()
    {
        dayFogDensity = RenderSettings.fogDensity;
    }

    void Update()
    {
        // Rotate the Sun
        transform.Rotate(Vector3.right, 100 * Time.deltaTime);

        // Calculate the current angle of the Sun
        float sunAngle = transform.eulerAngles.x;

        // Determine if it is day or night based on the angle
        if (sunAngle > 180) // Night time
        {
            if (!isNight)
            {
                isNight = true;
            }
            currentFogDensity = Mathf.Min(currentFogDensity + fogDensityRate * Time.deltaTime, nightFogDensity);
        }
        else // Day time
        {
            if (isNight)
            {
                isNight = false;
            }
            currentFogDensity = Mathf.Max(currentFogDensity - fogDensityRate * Time.deltaTime, dayFogDensity);
        }

        // Set the fog density
        RenderSettings.fogDensity = currentFogDensity;
    }
}
