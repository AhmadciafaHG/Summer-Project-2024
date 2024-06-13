using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{    
    public float rotateSpeed = 5f;

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * rotateSpeed * Time.deltaTime); //Every frame, make this pickup rotate

    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject);
        GameManager.Instance.UpdateScore(1);
    }
}
