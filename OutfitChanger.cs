using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutfitChanger : MonoBehaviour
{
    [Header("Sprite to change")]
    public SpriteRenderer lBodyPart;
    public SpriteRenderer rPairBodyPart;

    public bool isPair;
    
    [Header("Sprites to Cycle Through")]
    public List<Sprite> options = new List<Sprite>();
    public List<Sprite> pairOptions = new List<Sprite>();


    private int current = 0;

    public void previous()
    {
        current--;
        if(current < 0)
            current = options.Count - 1;
        Change();
    }

    public void next()
    {
        current++;
        if (current >= options.Count)
            current = 0;
        Change();
    }

    public void Randomize()
    {
        current = Random.Range(0, options.Count);
        Change(); 
    }

    private void Change()
    {
        lBodyPart.sprite = options[current];
        if (isPair)
            rPairBodyPart.sprite = pairOptions[current];
    }
    
}
