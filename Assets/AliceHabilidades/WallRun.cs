using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WallRun : MonoBehaviour
{
    bool IsWallRunning;
    bool WallOnLeft;
    bool WallOnRight;

    public Rigidbody rb;

    public Transform orientation;
    public LayerMask WallRunLayer; 

    public float WallRunSpeed;
    public float WallStickStrngth;
    public float Reach;
    public float WallSwitchStrngth;
    public float WallJumpForce;

    public Camera cam;
    public float RotationCam1;
    public float RotationCam2;
    public float RotationCam3;

    void Update()
    {
        WallOnRight = Physics.Raycast(transform.position, orientation.right, Reach,WallRunLayer);
        WallOnLeft = Physics.Raycast(transform.position, -orientation.right, Reach,WallRunLayer);
        CheckForWR();

        if(IsWallRunning != true)
        {
            StopWR();
        }

    }

    private void CheckForWR()
    {
        if(Input.GetKey("a") && WallOnLeft)
        {
            SartWR();
          
        }

        if (Input.GetKey("d") && WallOnRight)
        {     
            SartWR();
           
        }
        


        if (Input.GetKey("d") && WallOnLeft && IsWallRunning)
        {
             StopWR();
            rb.AddForce(orientation.right * WallSwitchStrngth * Time.deltaTime);
            rb.AddForce(orientation.up * WallJumpForce * Time.deltaTime);
            
        }

        if (Input.GetKey("a") && WallOnRight && IsWallRunning)
        {
             StopWR();
            rb.AddForce(-orientation.right * WallSwitchStrngth * Time.deltaTime);
            rb.AddForce(orientation.up * WallJumpForce * Time.deltaTime);
        }

                else if (!WallOnLeft && !WallOnRight )
        {
            StopWR();
        }
    }

    private void SartWR()
    {
        rb.useGravity = false;
        IsWallRunning = true;

        
       rb.AddForce(orientation.forward * WallRunSpeed * Time.deltaTime);
       
       if (WallOnRight){
            rb.AddForce(orientation.right * WallStickStrngth * Time.deltaTime);

            cam.transform.Rotate(Vector3.down, RotationCam1 * Time.deltaTime);
            cam.transform.Rotate(Vector3.forward, RotationCam2 * Time.deltaTime);
            cam.transform.Rotate(Vector3.left, RotationCam3 * Time.deltaTime);
        }

        if (WallOnLeft){
            rb.AddForce(-orientation.right * WallStickStrngth * Time.deltaTime);

            cam.transform.Rotate(Vector3.up, RotationCam1 * Time.deltaTime);
            cam.transform.Rotate(Vector3.forward, RotationCam2 * Time.deltaTime);
            cam.transform.Rotate(Vector3.right, RotationCam3 * Time.deltaTime);
        }
             
    }
    private void StopWR()
    {
        rb.useGravity = true;
        IsWallRunning = false;
        
    }


}