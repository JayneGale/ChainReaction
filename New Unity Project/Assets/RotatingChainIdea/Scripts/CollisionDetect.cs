using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetect : MonoBehaviour
{
    GameObject rotatingBoard;
    float setColliderOnDelay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetColliderOn());
    }

    
    IEnumerator SetColliderOn()
    {
        yield return new WaitForSeconds(setColliderOnDelay);
        GetComponent<Collider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.parent = rotatingBoard.transform;
        LinkCounter.instance.AddLinksAndCheckNeighbours(gameObject);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
    }

    public void SetRotatingBoard(GameObject board)
    {
        rotatingBoard = board;
    }
}
