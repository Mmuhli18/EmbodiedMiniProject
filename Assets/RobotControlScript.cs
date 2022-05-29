using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotControlScript : MonoBehaviour
{
    Vector3 pictureRotation;
    public RobotMode robotMode;
    public GameObject Player;
    public GameObject RobotTarget;
    bool turning;
    // Start is called before the first frame update
    void Start()
    {
        pictureRotation = transform.rotation.eulerAngles;
        
    }

    public bool checkingIfTurning()
    {
        if (robotMode == RobotMode.Still) return true;
        return turning;
    }

    public IEnumerator lookAtPlayer()
    {
        turning = true;
        RobotTarget.transform.LookAt(Player.transform);
        Vector3 targetRotation = RobotTarget.transform.rotation.eulerAngles;
        int escape = 0;
        while (!(targetRotation.y - 5 < transform.rotation.eulerAngles.y && targetRotation.y + 5 > transform.rotation.eulerAngles.y))
        {
            
            Vector3 rotation = transform.rotation.eulerAngles;
            if (rotation.y < targetRotation.y)
            {
                rotation.y += 0.02f;
            }
            else
            {
                rotation.y -= 0.02f;
            }
            transform.rotation = Quaternion.Euler(rotation);
            if(escape > 100)
            {
                break;
            }
            escape++;
        }
        turning = false;
        yield return 0;
    }

    public IEnumerator lookAtPicture()
    {
        turning = true;
        int escape = 0;
        while (!(pictureRotation.y - 5 < transform.rotation.eulerAngles.y && pictureRotation.y + 5 > transform.rotation.eulerAngles.y))
        {

            Vector3 rotation = transform.rotation.eulerAngles;
            if (rotation.y < pictureRotation.y)
            {
                rotation.y += 0.02f;
            }
            else
            {
                rotation.y -= 0.02f;
            }
            transform.rotation = Quaternion.Euler(rotation);
            if (escape > 100)
            {
                break;
            }
            escape++;
        }
        turning = false;
        yield return 0;
    }

    public enum RobotMode
    {
        Still, 
        Mimic,
        PreProgrammed
    }
}
