using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class KillBox : MonoBehaviour
{
    
    int goldLost;
    int silverLost;
    int copperLost;
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
 //       Debug.Log("Collider tag = " + col.gameObject.tag);

        if (col.gameObject.CompareTag("Gold"))
        {
            goldLost += 1;          
            AM.PlayOneShot("GoldFallsOffscreen");
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

        /*        when the game restarts, reset the lost links to zero
        if (Play Again)
                {
                goldLost = 0;
                silverLost = 0;
                copperLost = 0;
                }
        */
    }
    public List<int> LostLinkCount() {
        var list = new List<int> { goldLost, silverLost, copperLost};
        return list;
    }

}
