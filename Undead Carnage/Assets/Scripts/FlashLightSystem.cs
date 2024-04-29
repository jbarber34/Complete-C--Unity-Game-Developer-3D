using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightSystem : MonoBehaviour
{
    [SerializeField] float lightDecay = .5f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minAngle = 40f;

    Light myLight;

    private void Start()
    {
        myLight = GetComponent<Light>();
    }

    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (myLight.spotAngle <= minAngle)
        {
            return;
        }
        else
        {
            myLight.spotAngle -= angleDecay * Time.deltaTime;
            myLight.innerSpotAngle = myLight.spotAngle / 4f;
        }
    }

    private void DecreaseLightIntensity()
    {
        myLight.intensity -= lightDecay * Time.deltaTime;
    }

    public void AddLightAngle(float restoreAngle)
    {
        myLight.spotAngle += restoreAngle;
        myLight.innerSpotAngle = myLight.spotAngle / 4f;
    }

    public void AddLightIntensity(float restoreIntensity)
    {
        myLight.intensity += restoreIntensity;
    }
}
