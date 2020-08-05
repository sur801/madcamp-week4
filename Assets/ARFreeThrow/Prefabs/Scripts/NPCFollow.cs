using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    GameObject ThePlayer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        ThePlayer = GameObject.Find("AR Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 PlayerPosition = new Vector3(ThePlayer.transform.position.x-3, transform.position.y, ThePlayer.transform.position.z);

        transform.LookAt(PlayerPosition);
    }
}
