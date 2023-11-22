using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Disparo : MonoBehaviour
{
    public Transform firePoint;
    public Transform casketPoint;
    public int damage = 25;

    public Animator animar;

    private bool single = true;

    public GameObject shootFX, bloodFX;
    public GameObject casquillo;


    public static bool isAiming = false;

    public GameObject bullet;
    public Transform spawnPoint;

    public float shotForce = 500;


    void Start()
    {

    }

   void Update()
{
    if (Input.GetMouseButtonDown(1))
    {
        isAiming = true;
        animar.SetBool("Aim", true);

    }

    if (Input.GetMouseButtonUp(1))
    {
        isAiming = false;
        animar.SetBool("Aim", false);
    }


    if (Input.GetButtonDown("Fire1") && single)
    {
        animar.SetBool("Shoot", true);
        Debug.Log("disparo");
        
        GameObject newBullet;

        newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(firePoint.forward*shotForce);

        Destroy(newBullet, 20);
    }

    if (Input.GetButtonUp("Fire1"))
    {
        animar.SetBool("Shoot", false);
    }            
}

}
