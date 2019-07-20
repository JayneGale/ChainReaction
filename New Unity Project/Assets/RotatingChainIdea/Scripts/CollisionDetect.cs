using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    bool fired = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!fired)
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            transform.parent = collision.transform;
            fired = true;
        }

    }
}
