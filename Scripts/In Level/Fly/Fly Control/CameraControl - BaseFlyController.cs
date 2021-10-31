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
        CamFollower.transform.localPosition = Vector3.Slerp(CamFollower.transform.localPosition, CamClimbDist * EulerToDirection(-ResultEuler.x, ResultEuler.y)
        , cc.Multipler);
        // CamFollower.transform.localPosition = CamFolwClimbPos;
        CamFollower.transform.localEulerAngles = CamFolwClimbAdditionalEul + Vector3.right * (_view.y * -30) + new Vector3(-ResultEuler.x, (ResultEuler.y - 180), 0);
        
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
        CamFollower.transform.localPosition = Vector3.Slerp(CamFollower.transform.localPosition, CamFlightDist * EulerToDirection(-ResultEuler.x, ResultEuler
        .y) , cc.Multipler);
        CamFollower.transform.localEulerAngles = new Vector3(-ResultEuler.x, (ResultEuler.y - 180) , 0);
        // CamFollower.transform.localPosition = CamFolwFlightPos;
        return 0;
    }
}
