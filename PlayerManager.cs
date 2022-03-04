using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public AudioClip soundEffect;

    public int strawberryCount;
    public int bananaCount;


    public bool pickUpItem(GameObject obj) 
    {
        switch(obj.tag)
        {
            case Constants.TAG_STRAWBERRY:
                strawberryCount++;
                return true;
            case Constants.TAG_BANANA:
                bananaCount++;
                return true;
            default:
                Debug.LogWarning($"WARNING: No handler implemented for tag {obj.tag}.");
                return false;
        }
    }
}
