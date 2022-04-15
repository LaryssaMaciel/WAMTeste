using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public bool shake = false;

    void Update()
    {
        if (shake)
        {
            StartCoroutine(Shake(.2f, 1f));
        }
    }

    public IEnumerator Shake(float duracao, float magnitude)
    {
        Vector3 originalPos = new Vector3(0,0,-40.98025f);
        float timePas = 0;

        while (timePas < duracao)
        {
            float xOffset = Random.Range(-.5f, .5f) * magnitude;
            float yOffset = Random.Range(-.5f, .5f) * magnitude;

            transform.localPosition = new Vector3(xOffset, yOffset, originalPos.z);
            timePas += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        shake = false;
    }
}
