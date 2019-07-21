using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect2 : MonoBehaviour
{

    float delay = 0.3f;
    public bool isKillSwitch = true;
    bool killSwitch;
    float time = 0f;

    private void Start()
    {
        killSwitch = isKillSwitch;
    }

    void Update()
    {
        if (killSwitch)
        {
            time += Time.deltaTime;
            if(time > delay)
            {
                Destroy(gameObject);
                //Ergh! Missed sound.
            }

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Substring(0,4) == "link")
        {
            other.gameObject.GetComponent<CollisionDetect2>().killSwitch = false;
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            Debug.Log("Collision", other.gameObject);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            AudioManager.instance.PlayOneShot("LinksConnect");
            LinkCounter.instance.AddLinksAndCheckNeighbours(gameObject);
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
    }
}
