using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class StuffsDisappear : MonoBehaviour
{
    [SerializeField] private GameObject[] stuffs;
    [SerializeField] private Light[] lights;
    [SerializeField] private Volume Volume;


    private int stuffsCount = 0;
    private float _time;
    private float timing = 2f;

    public IEnumerator ActiveDisappear()
    {
        while (stuffsCount < stuffs.Length)
        {
            if (stuffsCount == stuffs.Length - 2)
            {
                yield return new WaitForSeconds(6f);
                stuffs[stuffs.Length - 2].GetComponent<StuffsFadeOut>().SetIsFadeOut(true);
                stuffs[stuffs.Length - 1].GetComponent<StuffsFadeOut>().SetIsFadeOut(true);
            }

            yield return new WaitForSeconds(timing);

            stuffs[stuffsCount].GetComponent<StuffsFadeOut>().SetIsFadeOut(true);

            stuffsCount += 1;
            timing -= 0.5f;
            if (timing < 0.5) timing = 0.05f;
            if (stuffsCount == stuffs.Length) break;
        }
        yield return new WaitForSeconds(3f);

        float fadeDuration = 2f;
        float fadeTime = 0f;

        if (Volume.profile.TryGet(out ColorAdjustments colorAdjustments))
        {
            float initialPostExposure = colorAdjustments.postExposure.value;
            while (fadeTime < fadeDuration)
            {
                fadeTime += Time.deltaTime;
                float t = fadeTime / fadeDuration;

                colorAdjustments.postExposure.value = Mathf.Lerp(initialPostExposure, -50f, t);


                yield return null;
            }
        }


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
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("TheEnd");
    }
}
