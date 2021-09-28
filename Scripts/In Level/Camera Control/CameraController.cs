using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject FollowUp;

    public float Multipler = 0.2f;
    public float MultiplerAngle = 0.2f;

    // Update is called once per frame
    private void LateUpdate()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, FollowUp.transform.rotation, MultiplerAngle);
        transform.position = Vector3.Lerp(transform.position, FollowUp.transform.position, Multipler);
    }
}