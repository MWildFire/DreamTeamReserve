﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSmouse : MonoBehaviour {

public enum RotationAxes 
{
   MouseXandY = 0,
   MouseX = 1,
   MouseY = 2
}
   public RotationAxes axes = RotationAxes.MouseXandY;

   public float speedHor = 2.0f;
   public float speedVer = 2.0f;

   public float minimumVert = -45.0f;
   public float maximumVert = 45.0f;

    private float _rotationX = 0;

    void Update()
{
	 if (axes == RotationAxes.MouseX)
	 {
         transform.Rotate (0, speedHor * Input.GetAxis("Mouse X"), 0);
	 }
     else if (axes == RotationAxes.MouseY)
	 {
            _rotationX -= Input.GetAxis("Mouse Y") * speedVer;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);

     }
	 else
	 {
            _rotationX -= Input.GetAxis("Mouse Y") * speedVer;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * speedVer;
            float rotationY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
	 }
   }

}
