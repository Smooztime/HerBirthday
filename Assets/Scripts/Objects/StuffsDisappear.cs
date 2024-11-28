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
            if (stuffsCount == stuffs.Length - 1) timing = 6;
            Debug.Log(timing);

            yield return new WaitForSeconds(timing);
            Debug.Log(stuffs[stuffsCount]);

            stuffs[stuffsCount].GetComponent<StuffsFadeOut>().SetIsFadeOut(true);

            stuffsCount += 1;
            timing -= 0.5f;
            if (timing < 0.5) timing = 0.2f;
            if (stuffsCount == stuffs.Length) break;
        }
    }
}
