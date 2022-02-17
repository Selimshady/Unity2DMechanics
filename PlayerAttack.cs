using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject projectile;

    public Transform spawnPos;

    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            projectile = ObjectPooler.current.GetPoolObject();
            if(projectile == null) return;
            projectile.transform.position = spawnPos.position;
            projectile.transform.rotation = spawnPos.rotation;
            projectile.SetActive(true);
        }
    }
}
