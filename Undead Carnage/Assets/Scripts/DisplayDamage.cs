using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{
    [SerializeField] float impactTime = 0.5f;
    [SerializeField] UnityEngine.UI.Image splatterImage;

    void Start()
    {
        SetOpacity(0);
    }

    // 0 -> Fully Transparent; 1 -> Fully Opaque
    private void SetOpacity(float opacity)
    {
        Color color = splatterImage.color; // store the image's color component in a variable
        color.a = opacity; // set alpha component
        splatterImage.color = color; // assign the new color back to the image
    }

    public void ShowDamageImpact()
    {
        StartCoroutine(ShowImpact());
    }

    IEnumerator ShowImpact()
    {
        float opacity = 1f;
        float percentDone = 0;

        SetOpacity(opacity);
        while (opacity > 0)
        {
            yield return new WaitForEndOfFrame();

            opacity = Mathf.Lerp(1, 0, percentDone);
            percentDone += Time.deltaTime / impactTime; // percentDone will equal 1 after "impactTime" seconds 
            SetOpacity(opacity);
        }

        SetOpacity(0);
    }
}
