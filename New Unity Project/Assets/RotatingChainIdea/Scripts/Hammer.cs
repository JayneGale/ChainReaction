using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour
{
    public List<GameObject> linkPrefabs;
    int linkPrefabIndex;
    public List<Sprite> spriteList;
    public SpriteRenderer linkSpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        linkPrefabIndex = Random.Range(0, linkPrefabs.Count);
        SetLinkSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            CreateLink();
            linkPrefabIndex = Random.Range(0, linkPrefabs.Count);
            SetLinkSprite();
        }
    }

    void CreateLink()
    {
        GameObject link = linkPrefabs[linkPrefabIndex];
        Vector3 linkPosition = new Vector3(transform.position.x, transform.position.y, 0);
        Instantiate(link, linkPosition, Quaternion.identity);
        AudioManager.instance.PlayOneShot("Hammer3");
    }

    void SetLinkSprite()
    {
        linkSpriteRenderer.sprite = spriteList[linkPrefabIndex];
        linkSpriteRenderer.color = linkPrefabs[linkPrefabIndex].GetComponent<SpriteRenderer>().color;
    }
}
