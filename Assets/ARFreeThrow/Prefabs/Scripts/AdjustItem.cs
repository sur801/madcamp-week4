using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustItem : MonoBehaviour
{
    GameObject healthBar;
    GameObject myBall;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = GameObject.FindGameObjectsWithTag("healthbar")[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ball" && gameObject.tag =="portion"){
            Destroy(gameObject);
            healthBar.gameObject.transform.localScale += new Vector3(0.2f, 0 , 1);
        } else if(other.gameObject.tag == "ball" && gameObject.tag == "sizeup") {
            Destroy(gameObject);
            myBall = GameObject.FindGameObjectsWithTag("ball")[0];
            myBall.gameObject.transform.localScale +=  new Vector3(0.005f, 0.005f , 0.005f);
        }
    }
}
