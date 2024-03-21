using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Construction : MonoBehaviour
{

    public GameObject[] buildingParts;

    private void Start()
    {
        StartCoroutine(Build());
    }

    IEnumerator Build()
    {
        foreach (GameObject part in buildingParts)
        {
            yield return StartCoroutine(ScaleIn(part.transform));
        }
    }

    IEnumerator ScaleIn(Transform transform)
    {
        float duration = 1f;
        float time = 0;

        Vector3 initialScale = transform.localScale;
        Vector3 targetScale = new Vector3(1, 1, 1);

        while (time < duration)
        {
            time += Time.deltaTime;
            transform.localScale = Vector3.Lerp(initialScale, targetScale, time/duration);
            yield return null;
        }
    }
}
