using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
[RequireComponent(typeof(Rigidbody))]
public class BallControl : MonoBehaviour
{
    // force of the throw
    public float m_ThrowForce = 200f;
    public float m_ThrowDirectionX = 0.17f;
    public float m_ThrowDirectionY = 0.67f;
    // offset of the ball's position in relation to camera's position
    public Vector3 m_BallCameraOfffset = new Vector3(0f, -0.4f, 1f);
    // The following variables contain the state of the current throw
    private Vector3 startPosition;
    private Vector3 direction;
    private float startTime;
    private float endTime;
    private float duration;
    private bool directionChosen = false;
    private bool throwStarted = false;
    [SerializeField]
    GameObject ARCam;
    [SerializeField]
    ARSessionOrigin m_SessionOrigin;

    Animator animator;
    public GameObject smoke;

    Rigidbody rb;
    private void Start(){
        rb = gameObject.GetComponent<Rigidbody>();
        m_SessionOrigin = GameObject.Find("AR Session Origin").GetComponent<ARSessionOrigin>();
        ARCam = m_SessionOrigin.transform.Find("AR Camera").gameObject;
        transform.parent = ARCam.transform;
        ResetBall();
    }
    private void Update(){
        // We've started the touch of the screen, which will start the ball throw
        if(Input.GetMouseButtonDown(0)) {
            startPosition = Input.mousePosition;
            startTime = Time.time;
            throwStarted = true;
            directionChosen = false;
            // We've ended the touch of the screen, which will release/throw the ball
        } else if (Input.GetMouseButtonUp(0)) {
            // Work for both Mouse and Touch, when we release click/touch
            endTime = Time.time;
            duration = endTime = startTime;
            direction = Input.mousePosition - startPosition;
            directionChosen = true;
        }
        // Direction is chosen, which will release/throw the ball
        if(directionChosen) {
            rb.mass = 2;
            rb.useGravity = true;
            rb.AddForce(
                ARCam.transform.forward * m_ThrowForce / duration + 
                ARCam.transform.up * direction.y * m_ThrowDirectionY + 
                ARCam.transform.right * direction.x * m_ThrowDirectionX);
            startTime = 0.0f;
            duration = 0.0f;
            startPosition = new Vector3(0,0,0);
            throwStarted = false;
            directionChosen = false;
        }
        // 5 seconds after throwing the ball, we reset it's position
        if(Time.time - endTime >=2 && Time.time - endTime <= 3)
            ResetBall();
    }
    public void ResetBall(){
        rb.mass = 0;
        rb.useGravity = false ;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        endTime = 0.0f;
        Vector3 ballPos = ARCam.transform.position + ARCam.transform.forward * m_BallCameraOfffset.z + ARCam.transform.up * m_BallCameraOfffset.y;
        transform.position = ballPos;
    }

    

    

    
}