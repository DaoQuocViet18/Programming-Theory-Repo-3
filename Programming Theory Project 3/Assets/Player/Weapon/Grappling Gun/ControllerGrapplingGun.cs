using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGrapplingGun : MonoBehaviour
{
    GrapplingGun GG1;
    GrapplingGun GG2;
    PlayerCam PC;
    int numberGrapplingGun;
    void Awake()
    {
        GG1 = GameObject.Find("GearLeft").GetComponent<GrapplingGun>();
        GG2 = GameObject.Find("GearRight").GetComponent<GrapplingGun>();
        PC = GameObject.Find("Main Camera").GetComponent<PlayerCam>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PC.yRotation < -30f && PC.yRotation > -150f)
        {
            numberGrapplingGun = 1;
        }
        else if (PC.yRotation > 30f && PC.yRotation < 150f)
        {
            numberGrapplingGun = 2;
        }
        else if (PC.yRotation > -30f && PC.yRotation < 30f || PC.yRotation > -150f && PC.yRotation < 150f)
        {
            numberGrapplingGun = 3;
        }

        
        switch (numberGrapplingGun)
        {
            case 1:
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        GG2.StopGrapple();
                        GG1.StartGrapple();
                    }
                    else if (Input.GetMouseButtonUp(1))
                    {
                        GG1.StopGrapple();
                    }
                    break;
                }

            case 2:
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        GG1.StopGrapple();
                        GG2.StartGrapple();
                    }
                    else if (Input.GetMouseButtonUp(1))
                    {
                        GG2.StopGrapple();
                    }                  
                    break;
                }
            case 3:
                {
                    if (Input.GetMouseButtonDown(1))
                    {
                        GG1.StartGrapple();
                        GG2.StartGrapple();
                    }
                    else if (Input.GetMouseButtonUp(1))
                    {
                        GG1.StopGrapple();
                        GG2.StopGrapple();
                    }
                    break;
                }
        }

        
    }
}
