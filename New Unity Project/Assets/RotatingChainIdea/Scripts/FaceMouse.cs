using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float x = mouseWorldPos.x - transform.position.x;
        float y = mouseWorldPos.y - transform.position.y;
        print(x);
        //print(y);
        float angle = Mathf.Abs(Mathf.Atan(x/y)) * 180/Mathf.PI;
        float sign = Mathf.Sign(mouseWorldPos.x);
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, sign * angle);
    }
}
