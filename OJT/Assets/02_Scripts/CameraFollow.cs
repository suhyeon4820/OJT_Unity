using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 cameraOffSet;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 currentVelocity = Vector3.zero;

    //private void Awake()
    //{
    //    cameraOffSet = transform.position - target.position;
    //}

    //private void LateUpdate()
    //{
    //    Vector3 targetPosition = target.position + cameraOffSet;
    //    transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime);
    //}

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + cameraOffSet;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothTime);
        transform.position = smoothedPosition;
    }
}
