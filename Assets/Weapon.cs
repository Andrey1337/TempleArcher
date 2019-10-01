using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;

    public Rigidbody2D rb;
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        arrowPrefab.transform.Rotate(0,180f,0);
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
