using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffsFadeOut : MonoBehaviour
{
    private bool isFadeOut = false;

    private void Update()
    {
        if(isFadeOut)
        {
            StartCoroutine(FadeOut());
        }    
    }

    private IEnumerator FadeOut()
    {
        var stuffMat = gameObject.GetComponent<Renderer>().material;
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
        gameObject.SetActive(false);
    }

    public void SetIsFadeOut(bool value)
    {
            isFadeOut = value;
    }
}
