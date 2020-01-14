using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Transform cameraTransform;
    public float Amplitude { get; set; }

    private Coroutine coroutine_shake;



    private void Awake()
    {
        cameraTransform = GetComponent<Transform>();
    }

    public void Shake(float seconds)
    {
        if (coroutine_shake != null)
            StopCoroutine(coroutine_shake);

        coroutine_shake = StartCoroutine(ShakeCoroutine(seconds));
    }

    private IEnumerator ShakeCoroutine(float seconds)
    {
        float timer = 0;

        while(timer <= seconds)
        {
            timer += Time.deltaTime;

            Vector3 randomDirection = new Vector3(Random.Range(-1, 1f), Random.Range(-1, 1f), 0);

            cameraTransform.position = Vector3.Lerp(cameraTransform.position, cameraTransform.position + randomDirection * Amplitude, 0.5f);
            yield return new WaitForSeconds((1 / 10f) * Time.timeScale);
        }
    }
}