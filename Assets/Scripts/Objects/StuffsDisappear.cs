using System.Collections;
using UnityEngine;

public class StuffsDisappear : MonoBehaviour
{
    [SerializeField] private GameObject[] stuffs;
    private int stuffsCount = 0;
    private float _time;
    private float timing = 6f;

    private void Start()
    {
        StartCoroutine(ActiveDisappear());
    }

    private IEnumerator ActiveDisappear()
    {
        while (stuffsCount < stuffs.Length)
        {
            Debug.Log(timing);

            yield return new WaitForSeconds(timing);
            stuffsCount += 1;
            timing -= 0.5f;
            if (timing < 0.5) timing = 0.1f;
            if (stuffsCount == stuffs.Length) break;

            StartCoroutine(FadeOut(stuffs[stuffsCount]));
            


        }
    }

    private IEnumerator FadeOut(GameObject stuff)
    {
        var stuffMat = stuff.GetComponent<Renderer>().material;
        stuffMat.SetFloat("_Surface", 1);
        stuffMat.SetInt("_ZWrite", 0);
        stuffMat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        stuffMat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        stuffMat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        float fadeDuration = 2f;
        float fadeTime = 0f;

        while (fadeTime < fadeDuration)
        {
            fadeTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeTime / fadeDuration);
            stuffMat.color = new Color(stuffMat.color.r, stuffMat.color.g, stuffMat.color.b, alpha);
            yield return null;
        }
        stuffs[stuffsCount].gameObject.SetActive(false);
    }
}
