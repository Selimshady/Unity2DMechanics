using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowManAttacks : MonoBehaviour
{
    public Transform firePosition;
    public float coolDown = 5f;

    private GameObject projectile;
    private float currentCoolDown;

    private void Start() {
        currentCoolDown = coolDown;
    }
    

    void Update()
    {
        currentCoolDown-=Time.deltaTime;
        if(currentCoolDown < 0) 
        {
            projectile = ObjectPooler.current.GetPoolObject();
            if(projectile != null)  Fire();
            currentCoolDown = coolDown;
        } 
    }

    private void Fire()
    {
        projectile.transform.position = firePosition.position;
        projectile.transform.rotation = firePosition.rotation;
        projectile.SetActive(true);
    }
}
