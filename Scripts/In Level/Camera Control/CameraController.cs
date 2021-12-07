using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    // The object that the camera will follow on
    public GameObject FollowUp;

    /// <summary>
    /// Lerp Value on Position
    /// </summary>
    public float Multipler = 0.2f;
    /// <summary>
    /// Lerp Value on Rotation
    /// </summary>
    public float MultiplerAngle = 0.2f;
    /// <summary>
    /// Lerp Value when using Freecam. Freecam is deprecated.
    /// </summary>
    [Obsolete]
    public float MultiplerFreeCam = 0.05f;
    public float changingmultiplier;
    /// <summary>
    /// GUI Indication 
    /// </summary>
    public RectTransform TheRing;

    /// <summary>
    /// Turn on Freecam Mode. This is obsolete as freecam is now implemented on Fly Controller.
    /// </summary>
    [Obsolete]
    public bool Freecam = false;
    public Vector3 CamLookingEulerOffset = Vector3.zero;
    private Vector3 LockDownLookingDirection = Vector3.zero;



    private void Start(){
        transform.position = FollowUp.transform.position;
        changingmultiplier = Multipler;
    }
    // Update is called once per frame
    private void Update()
    {
        if (!Freecam)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, FollowUp.transform.rotation, Mathf.Clamp(MultiplerAngle * Time.deltaTime, 0.0f, 999.0f));
            LockDownLookingDirection = transform.localEulerAngles;
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(LockDownLookingDirection + CamLookingEulerOffset), MultiplerFreeCam * Time.deltaTime);
        }
        if(Vector3.Distance (FollowUp.transform.position, transform.position) > 0.0f){
            //changingmultiplier = Mathf.Pow(Vector3.Distance (FollowUp.transform.position, transform.position),5) * Multipler;
            
        }
        transform.position = Vector3.Lerp(transform.position, FollowUp.transform.position, Mathf.Clamp(changingmultiplier * Time.deltaTime, 0.0f , 999.0f));
        TheRing.position = new Vector3(CamLookingEulerOffset.y, -CamLookingEulerOffset.x, 5) + Camera.main.ViewportToScreenPoint(new Vector3(0.5f, 0.5f, 0));
        
    }

}