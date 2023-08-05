using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nukeemission : MonoBehaviour
{
    public Material flickeringMaterial;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float flickerSpeed = 0.5f;

    private bool isFlickering = false;

    private void Start()
    {
        if (flickeringMaterial == null)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null)
            {
                flickeringMaterial = renderer.material;
            }
            else
            {
                Debug.LogError("No Material assigned and no Renderer component found!");
                return;
            }
        }

        StartFlickering();
    }

    private void StartFlickering()
    {
        if (!isFlickering)
        {
            isFlickering = true;
            StartCoroutine(FlickerCoroutine());
        }
    }

    private void StopFlickering()
    {
        if (isFlickering)
        {
            isFlickering = false;
            StopCoroutine(FlickerCoroutine());
        }
    }

    private IEnumerator FlickerCoroutine()
    {
        while (isFlickering)
        {
            float targetIntensity = Random.Range(minIntensity, maxIntensity);
            flickeringMaterial.EnableKeyword("_EMISSION");
            flickeringMaterial.SetColor("_EmissionColor", flickeringMaterial.color * targetIntensity);
            yield return new WaitForSeconds(flickerSpeed);
        }

        // Reset emission to zero when not flickering
        flickeringMaterial.EnableKeyword("_EMISSION");
        flickeringMaterial.SetColor("_EmissionColor", Color.black);
    }
}
