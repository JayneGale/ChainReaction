using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHand : MonoBehaviour
{
    public GameObject hammer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
        SetHammerPosition();
    }

    void SetPosition()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, -5);
    }
    void SetHammerPosition()
    {
        hammer.transform.localPosition = Vector3.ClampMagnitude(hammer.transform.localPosition + new Vector3(Random.Range(-0.15f,0.15f), Random.Range(-0.15f, 0.15f),0), 0.5f);
    }
}
