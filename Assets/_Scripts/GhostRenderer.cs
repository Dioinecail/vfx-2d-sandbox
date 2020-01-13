using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRenderer : MonoBehaviour
{
    private void OnEnable()
    {
        Animation fadeAnimation = GetComponent<Animation>();

        Invoke("DestroySelf" , fadeAnimation.clip.length);
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}