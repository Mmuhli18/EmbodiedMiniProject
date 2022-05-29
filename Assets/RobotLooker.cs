using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLooker : MonoBehaviour
{
    public GameObject Robot;
    RobotControlScript robotControl;
    private void Start()
    {
        robotControl = Robot.GetComponent<RobotControlScript>();
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit) && robotControl.robotMode == RobotControlScript.RobotMode.Mimic)
        {
            if(hit.transform.gameObject == Robot && !robotControl.checkingIfTurning())
            {
                StartCoroutine(robotControl.lookAtPlayer());
            }
            else if(!robotControl.checkingIfTurning())
            {
                StartCoroutine(robotControl.lookAtPicture());
            }
        }
    }
}
