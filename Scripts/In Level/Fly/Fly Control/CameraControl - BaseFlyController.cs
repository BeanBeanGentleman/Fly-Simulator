using UnityEngine;
using UnityEngine.Serialization;


public partial class BaseFlyController
{
    
    public GameObject CamFollower;
    public Vector3 CamFolwOrigPos;
    public Vector3 CamFolwClimbPos;
    [FormerlySerializedAs("CamFolwClimbEul")] public Vector3 CamFolwClimbAdditionalEul;

    public Vector3 CamFolwFlightDefaultEuler;
    public Vector3 CamFolwClimbDefaultEuler;

    public float CamFlightDist = 5;
    public float CamClimbDist = 5;

    public Vector3 TargetAngle = Vector3.zero;

    public float CamMultiplier = 0.02f;

    public int ClimbCamControl()
    {
        Vector3 ResultEuler = CamFolwClimbDefaultEuler;
        if (_useFreeCam)
        {
            // cc.Freecam = true;
            // cc.CamLookingEulerOffset = new Vector3(-_alignment.y, _alignment.x,  0) * 180;
            ResultEuler += new Vector3(_alignment.y * 22.5f, _alignment.x * 180, 0) ;
        }
        else
        {
            // cc.Freecam = false;
        }

        float Dist = CamClimbDist * 2;
        Ray ray = new Ray(this.transform.position, cc.transform.position - this.transform.position);
        RaycastHit hitt;
        if (Physics.Raycast(ray, out hitt))
        {
            Dist = hitt.distance;
        }
        TargetAngle = Vector3.Lerp(TargetAngle, ResultEuler, CamMultiplier);
        CamFollower.transform.localPosition = Mathf.Min(Dist, CamClimbDist) * EulerToDirection(-TargetAngle.x, TargetAngle.y);
        // CamFollower.transform.localPosition = CamFolwClimbPos;
        CamFollower.transform.localEulerAngles = CamFolwClimbAdditionalEul + Vector3.right * (_view.y * -30) + new Vector3(-TargetAngle.x, (TargetAngle.y - 180), 0);
        
        this.Looking.SetActive(Mathf.Min(Dist, CamClimbDist) > 0.5f);
        
        return 0;
    }
    public int FlightCamControl()
    {
        
        Vector3 ResultEuler = CamFolwFlightDefaultEuler;
        if (_useFreeCam)
        {
            // cc.Freecam = true;
            // cc.CamLookingEulerOffset = new Vector3(-_alignment.y, _alignment.x,  0) * 180;
            ResultEuler += new Vector3(_alignment.y * 89, _alignment.x * 180, 0);
        }
        else
        {
            // cc.Freecam = false;
        }
        
        float Dist = CamClimbDist * 2;
        Ray ray = new Ray(this.transform.position, cc.transform.position - this.transform.position);
        RaycastHit hitt;
        if (Physics.Raycast(ray, out hitt))
        {
            Dist = hitt.distance;
        }
        
        TargetAngle = Vector3.Lerp(TargetAngle, ResultEuler, CamMultiplier);
        CamFollower.transform.localPosition = Mathf.Min(Dist, CamFlightDist) * EulerToDirection(-TargetAngle.x, TargetAngle.y);
        CamFollower.transform.localEulerAngles = new Vector3(-TargetAngle.x, (TargetAngle.y - 180) , 0);
        
        this.Looking.SetActive(Mathf.Min(Dist, CamFlightDist) > 0.5f);
        
        // CamFollower.transform.localPosition = CamFolwFlightPos;
        return 0;
    }
}
