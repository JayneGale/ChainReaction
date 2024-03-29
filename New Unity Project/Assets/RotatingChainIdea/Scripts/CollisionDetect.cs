﻿using System.Collections;
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
        Debug.Log("Collision", collision.gameObject);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        transform.parent = rotatingBoard.transform;
        AudioManager.instance.PlayOneShot("LinksConnect");
        LinkCounter.instance.AddLinksAndCheckNeighbours(gameObject);
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
    }

    public void SetRotatingBoard(GameObject board)
    {
        rotatingBoard = board;
    }
}
