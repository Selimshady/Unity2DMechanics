using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    public AudioClip soundEffect;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerManager manager = other.GetComponent<PlayerManager>();
        if(manager)
        {
            if(manager.pickUpItem(gameObject))
            {
                RemoveItem();
            }
        }
    }

    private void RemoveItem()
    {

        AudioManager.instance.playClip(soundEffect);
        Destroy(gameObject);
    }
}
