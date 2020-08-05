using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public GameObject gameOver;
    public GameObject healthBar;
    // Start is called before the first frame update
    void Start()
    {
       gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "daoBall") {
            //Destroy(healthBar.gameObject);
            
            //healthBar.gameObject.transform.localScale -= new Vector3(0.1f, 0 , 1);
            if(healthBar.gameObject.transform.localScale.x >= 0.0f) {
                healthBar.gameObject.transform.localScale -= new Vector3(0.4f, 0 , 1);
            }else {
                gameOver.SetActive(true);
                //healthBar.gameObject.SetActive(false);
               
            }
        }
    }
    void OnCollisionEnter(Collision other)
    {
        
    }
}
