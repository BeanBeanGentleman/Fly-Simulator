using UnityEngine;
using UnityEngine.Serialization;
using System.Collections;

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
    public Vector3 cur_destination;
    public Vector3 cur_startpoint;
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
        /*if (timeElapsed < lerpDuration){
            TargetAngle = Vector3.Lerp(TargetAngle, ResultEuler, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else 
        {
            TargetAngle = ResultEuler;
        }*/
        TargetAngle = Vector3.Lerp(TargetAngle, ResultEuler, CamMultiplier);
        CamFollower.transform.localPosition = Vector3.Lerp(CamFollower.transform.localPosition, Mathf.Min(Dist, CamClimbDist) * EulerToDirection(-TargetAngle.x, TargetAngle.y), 0.01f);
        // CamFollower.transform.localPosition = CamFolwClimbPos;
        if (EulerCheck == false){
            if(cur_destination == null){
                cur_startpoint = CamFollower.transform.localEulerAngles;
            }
            else{
                cur_startpoint = cur_destination;
            }
            cur_destination = CamFolwClimbAdditionalEul + Vector3.right * (_view.y * -30) + new Vector3(-TargetAngle.x, (TargetAngle.y - 180));
            EulerCheck = true;
        }
        CamFollower.transform.localEulerAngles = Vector3.Lerp(cur_startpoint, cur_destination, 0.01f);
        CamFollower.transform.localEulerAngles = CamFolwClimbAdditionalEul + Vector3.right * (_view.y * -30) + new Vector3(-TargetAngle.x, (TargetAngle.y - 180));
        if(islanding == false){
            StartCoroutine(input_lock());
        }
        
        this.Looking.SetActive(Mathf.Min(Dist, CamClimbDist) > 0.5f);
        
        return 0;
    }

    public IEnumerator input_lock(){
        islanding=true;
        
        yield return new WaitForSeconds(2);
        print("move");
        islanding = false;
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
        CamFollower.transform.localPosition = Vector3.Lerp(CamFollower.transform.localPosition, Mathf.Min(Dist, CamClimbDist) * EulerToDirection(-TargetAngle.x, TargetAngle.y), 0.01f);
        //print(CamFollower.transform.localPosition);
        //print(Mathf.Min(Dist, CamFlightDist) * EulerToDirection(-TargetAngle.x, TargetAngle.y) + this.transform.position);
        //CamFollower.transform.position = Mathf.Min(Dist, CamFlightDist) * EulerToDirection(-TargetAngle.x, TargetAngle.y) + this.transform.position;
        
        if (EulerCheck == true){
            cur_startpoint = cur_destination;
            cur_destination = new Vector3(-TargetAngle.x, (TargetAngle.y - 180) , 0);
            EulerCheck = false;
        }
        CamFollower.transform.localEulerAngles = Vector3.Lerp(cur_startpoint, cur_destination, 0.01f);
        this.Looking.SetActive(Mathf.Min(Dist, CamFlightDist) > 0.5f);
        
        //CamFollower.transform.localPosition = CamFolwFlightPos;
        return 0;
    }
}
