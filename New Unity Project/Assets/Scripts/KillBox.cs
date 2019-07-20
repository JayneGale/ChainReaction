using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KillBox : MonoBehaviour
{
    [HideInInspector]
    public int goldLost;
    [HideInInspector]
    public int silverLost;
    [HideInInspector]
    public int copperLost;
    AudioManager AM;
    AudioSource AMSource;

    private void Start()
    {
        goldLost = 0;
        silverLost = 0;
        copperLost = 0;
        AM = FindObjectOfType<AudioManager>();
    }


    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.CompareTag("Gold"))
        {
            goldLost += 1;          
            AM.PlayOneShot("GoldFallsOffscreen");
 //           Debug.Log("Gold lost = " + goldLost);

        }
        if (col.gameObject.CompareTag("Silver"))
        {
            silverLost += 1;
            AM.PlayOneShot("LinkFallsOffscreen");

        }
        if (col.gameObject.CompareTag("Copper"))
        {
            copperLost += 1;
           AM.PlayOneShot("LinkFallsOffscreen");
        }
        Destroy(col.gameObject);
    }
    public List<int> LostLinkCount() {
        var list = new List<int> { goldLost, silverLost, copperLost};
        return list;
    }

}
