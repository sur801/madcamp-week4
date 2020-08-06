using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopScript : MonoBehaviour
{
    [SerializeField]
    public GameObject arCamera;
    public static Vector3 pos;

    
    public static void Pop() {
        Instantiate(Resources.Load("CFX4 Hit Paint C (Cyan)"), pos,Quaternion.identity);
    }
}
