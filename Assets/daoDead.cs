using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class daoDead : MonoBehaviour
{
    Animator animator;
    [SerializeField]
    public GameObject m_BallPrefab;
    // Start is called before the first frame update
    void Start()
    {
        animator  = GetComponent<Animator>();
        //Debug.Log("start");
        //animator.SetBool("hit", false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("update");
    }


    /// <summary>
    /// The object instantiated as a result of a successful raycast intersection with a plane.
    /// </summary>
    public GameObject spawnedBall { get; private set; }


    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionEnter(Collision other)
    {
        Destroy(other.gameObject); // destroy balloon
        PopScript.pos = other.contacts[0].point;
        PopScript.Pop();
        animator.SetBool("hit", true);
        spawnedBall = Instantiate(m_BallPrefab);

    }

    // <summary>
    /// OnCollisionExit is called when this collider/rigidbody has
    /// stopped touching another rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    void OnCollisionExit(Collision other)
    {
        animator.SetBool("hit", false);
    }
}
