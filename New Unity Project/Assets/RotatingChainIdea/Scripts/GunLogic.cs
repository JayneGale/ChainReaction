using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLogic : MonoBehaviour
{
    int linkPrebabIndex;
    public List<int> typeOfLinksUsed = new List<int> {0,0,0};
    public GameObject rotatingBoard;
    public List<GameObject> linkPrefabs;
    public Vector3 hitStrength = new Vector3(0,-400,0);
    GameObject currentLink;
    float clickDelay = 0.4f;
    float delayTimer;
    // Start is called before the first frame update
    void Start()
    {
        List<float> boundList = new List<float>();
        boundList.Add(rotatingBoard.transform.position.y - rotatingBoard.transform.lossyScale.y/2);
        boundList.Add(rotatingBoard.transform.position.y + rotatingBoard.transform.lossyScale.y/2);
        boundList.Add(rotatingBoard.transform.position.x - rotatingBoard.transform.lossyScale.x/2);
        boundList.Add(rotatingBoard.transform.position.x + rotatingBoard.transform.lossyScale.x/2);
        //LinkCounter.instance.SetBoardBounds(boundList);
        GenerateNewLink();
    }

    // Update is called once per frame
    void Update()
    {
        delayTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0) && delayTimer > clickDelay)
        {
            FireLink();
            GenerateNewLink();
            delayTimer = 0;
        }
    }

    void FireLink()
    {
        typeOfLinksUsed[linkPrebabIndex] += 1;
        currentLink.transform.parent = null;
        currentLink.GetComponent<Rigidbody>().AddForce(transform.rotation * hitStrength);
        AudioManager.instance.PlayOneShot("Hammer3");
    }

    void GenerateNewLink()
    {
        linkPrebabIndex = Random.Range(0, linkPrefabs.Count);
        GameObject link = linkPrefabs[linkPrebabIndex];
        currentLink = Instantiate(link,transform,false);
        currentLink.GetComponent<CollisionDetect>().SetRotatingBoard(rotatingBoard);
    }
}
