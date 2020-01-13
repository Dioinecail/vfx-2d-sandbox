using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform camTransform;
    public Transform playerTransform;

    public float followSpeed;
    public Vector3 offset;


    void FixedUpdate()
    {
        Vector3 targetPosition = playerTransform.position + offset;

        camTransform.position = Vector3.Lerp(camTransform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
