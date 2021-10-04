using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public GameObject FollowUp;

    public float Multipler = 0.2f;
    public float MultiplerAngle = 0.2f;

    public RectTransform TheRing;

    public bool Freecam = false;
    public Vector3 FreecamLookingEulerOffset = Vector3.zero;
    private Vector3 LockDownLookingDirection = Vector3.zero;
    
    // Update is called once per frame
    private void FixedUpdate()
    {
        if(!Freecam)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, FollowUp.transform.rotation, MultiplerAngle);
            LockDownLookingDirection = transform.localEulerAngles;
        }
        else
        {
            transform.localEulerAngles = LockDownLookingDirection + FreecamLookingEulerOffset;
        }
        
        transform.position = Vector3.Lerp(transform.position, FollowUp.transform.position, Multipler);
    }

    private void Update()
    {
        TheRing.position = new Vector3(Mouse.current.position.x.ReadValue(), Mouse.current.position.y.ReadValue(), 5);
    }
}