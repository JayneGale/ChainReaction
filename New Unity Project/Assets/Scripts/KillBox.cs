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
  //      AM = FindObjectOfType<AudioManager>();
    }

    public List<int> LostLinkCount() {
        var list = new List<int> { goldLost, silverLost, copperLost};
        return list;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gold"))
        {
            goldLost += 1;
            //           Debug.Log("Gold lost = " + goldLost);

        }
        if (other.gameObject.CompareTag("Silver"))
        {
            silverLost += 1;

        }
        if (other.gameObject.CompareTag("Copper"))
        {
            copperLost += 1;
        }
        AudioManager.instance.PlayOneShot("GoldFallsOffscreen");
        Destroy(other.gameObject);
    }

}
