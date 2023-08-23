using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public KeyCode input;
    private float targetPressed;
    private float targetReleased;
 
    private new HingeJoint hingeJoint;

    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        targetPressed = hingeJoint.limits.max;
        targetReleased = hingeJoint.limits.min;
    }

    
    private void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        JointSpring joinSpring = hingeJoint.spring;
        if (Input.GetKey(input))
        {
            joinSpring.targetPosition = targetPressed;
        }
        else 
        {
            joinSpring.targetPosition = targetReleased;
        }

        GetComponent<HingeJoint>().spring = joinSpring;
    }

}
