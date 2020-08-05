using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowerScript : MonoBehaviour
{
    public GameObject theballPrefab;
    
    Animator animator;

    //////////////////
    public GameObject parentbone;
    public Rigidbody rigidbody;
    GameObject theball;

    bool alertString = false;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start the thrower script");
        theball = SpawnBall();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (alertString == true)
        {
            theball = SpawnBall();
            alertString = false;
        }
    }

    public void ThrowBall()
    {
        Debug.Log(parentbone.transform);
        ShootBall(theball);
        KillBall(theball);
        // spawn 의 타이밍 = idle 시작할때의 타이밍
        animator.SetBool("isIdle", true);
    }

    GameObject SpawnBall()
    {
        Debug.Log("spawn the ball");
        GameObject theball = (GameObject) Instantiate(theballPrefab);
        theball.GetComponent<Rigidbody>().useGravity = false;
        theball.transform.position = parentbone.transform.position;
        theball.transform.parent = parentbone.transform;
        return theball;
    }

    public void ShootBall(GameObject ball)
    {
        theball.transform.parent = null;
        theball.GetComponent<Rigidbody>().useGravity = true;
        theball.transform.rotation = parentbone.transform.rotation;
        theball.GetComponent<Rigidbody>().AddForce(theball.transform.forward*2000);
    }

    public void KillBall(GameObject ball)
    {
        Destroy(ball, 3.0f);
    }

    public void alert()
    {
            alertString = true;
    }
}
