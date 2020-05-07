using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouselook : MonoBehaviour
{
   
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float speedV = 9.0f;
    public float speedH = 9.0f;
    public float maxhead = 45.0f;
    public float minhead = -45.0f;
    private float _rotationX = 0.0f;
    // Use this for initialization
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) body.freezeRotation = true;//禁止旋转
    }

    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX) { transform.Rotate(0, Input.GetAxis("Mouse X") * speedH, 0); }
        if (axes == RotationAxes.MouseY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * speedV;
            _rotationX = Mathf.Clamp(_rotationX, minhead, maxhead);//限仰视俯视角度范围
            float _rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);//设置旋转角度

        }
        if (axes == RotationAxes.MouseXAndY)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * speedV;//注意是-=
            _rotationX = Mathf.Clamp(_rotationX, minhead, maxhead);//水平Verital
            float _rotationY = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * speedH;
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}