using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followcam : MonoBehaviour
{
   [SerializeField] 
    GameObject target;


    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + new Vector3(0,0,-10);
    }
}
