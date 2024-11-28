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
        var stuffMat = gameObject.GetComponent<Renderer>();
        if(stuffMat != null)
        {
            yield return StartCoroutine(FadeAway(stuffMat.material));
        }
        else
        {
            Renderer[] stuffMats = gameObject.GetComponentsInChildren<Renderer>();
            List<Coroutine> fadeCoroutine = new List<Coroutine>();

            foreach(Renderer stuff in stuffMats)
            {
                fadeCoroutine.Add(StartCoroutine(FadeAway(stuff.material)));
            }

            foreach(Coroutine fade in fadeCoroutine)
            {
                yield return fade;
            }
        }

        gameObject.SetActive(false);
    }

    private IEnumerator FadeAway(Material mat)
    {
        mat.SetFloat("_Surface", 1);
        mat.SetInt("_ZWrite", 0);
        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;

        float fadeDuration = 2f;
        float fadeTime = 0f;

        while (fadeTime < fadeDuration)
        {
            fadeTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, fadeTime / fadeDuration);
            mat.color = new Color(mat.color.r, mat.color.g, mat.color.b, alpha);
            yield return null;
        }
    }

    public void SetIsFadeOut(bool value)
    {
            isFadeOut = value;
    }
}
