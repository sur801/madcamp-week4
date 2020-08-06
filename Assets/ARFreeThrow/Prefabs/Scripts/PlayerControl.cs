using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    public GameObject gameOver;
    public GameObject gameWin;
    public GameObject healthBar;
    GameObject myBall;
    int DaoCnt;
    int BazziCnt;
    bool isStarted;
    bool isOver;
    // Start is called before the first frame update
    void Start()
    {

        isStarted = false;
        gameOver.SetActive(false);
        gameWin.SetActive(false);
        isOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        isStarted = UnityEngine.XR.ARFoundation.Samples.PlaceHoop.isPlaced;
        DaoCnt = GameObject.FindGameObjectsWithTag("enemyDao").Length;
        BazziCnt = GameObject.FindGameObjectsWithTag("enemyBazzi").Length;

        if(DaoCnt == 0 && BazziCnt == 0 && isStarted == true && !isOver) {
            // You win
            // Change bgm to win game over sound
            isOver = true;
            AudioSource source = gameObject.GetComponent<AudioSource>();
            source.clip = (AudioClip)Resources.Load("win");
            source.Play();
            gameWin.SetActive(true);
            myBall = GameObject.FindGameObjectsWithTag("ball")[0];
            myBall.SetActive(false);
        }
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
            if(healthBar.gameObject.transform.localScale.x > 0.1f) {
                healthBar.gameObject.transform.localScale -= new Vector3(0.1f, 0 , 1);
            }else {
                // Change bgm to win game over sound
                AudioSource source = gameObject.GetComponent<AudioSource>();
                source.clip = (AudioClip)Resources.Load("loose");
                source.Play();
                healthBar.gameObject.transform.localScale -= new Vector3(0.1f, 0 , 1);
                // Game Over
                gameOver.SetActive(true);// set visible to game over text
                myBall = GameObject.FindGameObjectsWithTag("ball")[0];
                myBall.SetActive(false);
                for(int i=0 ; i<DaoCnt ; i++) {
                    GameObject dao = GameObject.FindGameObjectsWithTag("enemyDao")[i];
                    dao.GetComponent<Animator>().SetBool("over", true);
                }
                for(int i=0 ; i<BazziCnt ; i++) {
                    GameObject bazzi = GameObject.FindGameObjectsWithTag("enemyBazzi")[i];
                    bazzi.GetComponent<Animator>().SetBool("over", true);
                }              
            }
        }
    }

}
