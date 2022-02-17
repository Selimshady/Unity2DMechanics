using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillStatusBar : MonoBehaviour
{
    public PlayerHealth playerHealth;    
    public Image fillImage;


    private float speed = 5f;
    private float fillValue;
    private Slider slider;
    
    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        fillValue = (float)playerHealth.currentHealth / playerHealth.maxHealth;
        slider.value = fillValue;

        if(slider.value < 0.3f)
            fillImage.color = new Vector4(1,0,0,Mathf.PingPong(Time.time * speed,1));
        else if(slider.value < 0.5f)
            fillImage.color = new Vector4(1,0,0,Mathf.PingPong(Time.time * speed/5,1));
        if(slider.value == 0)
            fillImage.enabled = false;
    }
}
