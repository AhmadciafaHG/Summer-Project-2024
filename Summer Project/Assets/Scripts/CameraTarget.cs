using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target; //Camera Position

    public Vector3 posOffset; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = target.position + posOffset;
      
    }
}
