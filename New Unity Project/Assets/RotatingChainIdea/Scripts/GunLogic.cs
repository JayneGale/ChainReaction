using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{

    public List<GameObject> links;
    public Vector3 hitStrength = new Vector3(0,-400,0);
    GameObject currentLink;
    // Start is called before the first frame update
    void Start()
    {
        GenerateNewLink();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            FireLink();
            GenerateNewLink();
        }
    }

    void FireLink()
    {
        currentLink.GetComponent<Rigidbody>().AddForce(transform.rotation * hitStrength);
    }

    void GenerateNewLink()
    {
        GameObject link = links[Random.Range(0,links.Count)];
        currentLink = Instantiate(link,transform,false);
    }
}
