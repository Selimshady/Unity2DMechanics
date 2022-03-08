using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip soundEffect;


    public void TakeCoin()
    {
        PlayerManager manager = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>();
        if(manager.pickUpItem(gameObject))
        {
            Debug.Log("Coin is taken");
            AudioManager.instance.playClip(soundEffect);
            Destroy(gameObject);
        }
    }
}
