using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class StuffsDisappear : MonoBehaviour
{
    [SerializeField] private GameObject[] stuffs;
    [SerializeField] private Light[] lights;
    [SerializeField] private Volume volume;
    private int stuffsCount = 0;
    private float _time;
    private float timing = 2f;

    private void Start()
    {
        StartCoroutine(ActiveDisappear());
    }

    private IEnumerator ActiveDisappear()
    {
        while (stuffsCount < stuffs.Length)
        {
            if (stuffsCount == stuffs.Length - 2)
            {
                yield return new WaitForSeconds(6f);
                stuffs[stuffs.Length - 2].GetComponent<StuffsFadeOut>().SetIsFadeOut(true);
                stuffs[stuffs.Length - 1].GetComponent<StuffsFadeOut>().SetIsFadeOut(true);
            }
            Debug.Log(timing);

            yield return new WaitForSeconds(timing);
            Debug.Log(stuffs[stuffsCount]);

            stuffs[stuffsCount].GetComponent<StuffsFadeOut>().SetIsFadeOut(true);

            stuffsCount += 1;
            timing -= 0.5f;
            if (timing < 0.5) timing = 0.05f;
            if (stuffsCount == stuffs.Length) break;
        }
        yield return new WaitForSeconds(3f);

        float fadeDuration = 2f;
        float fadeTime = 0f;

        

        float[] startIntensities = new float[lights.Length];
        for (int i = 0; i < lights.Length; i++)
        {
            startIntensities[i] = lights[i].intensity;
        }


        while (fadeTime < fadeDuration)
        {
            fadeTime += Time.deltaTime;
            float t = fadeTime / fadeDuration;

            for (int i = 0; i < lights.Length; i++)
            {
                lights[i].intensity = Mathf.Lerp(startIntensities[i], 0f, t);
            }

            yield return null;
        }

        foreach (Light light in lights)
        {
            light.intensity = 0f;
        }
    }
}
