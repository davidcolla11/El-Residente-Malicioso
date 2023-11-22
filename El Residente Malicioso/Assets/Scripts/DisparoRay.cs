using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DisparoRay : MonoBehaviour
{
    public Transform firePoint;
    public Transform casketPoint;
    public int damage = 25;

    public Animator animar;

    public LineRenderer lineRenderer;

    private bool single = true;

    public GameObject shootFX, bloodFX;
    public GameObject casquillo;

    float tiemDisparo = 1f;

    public static bool isAiming = false;

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
    // Desactivar la animación de "Aim" cuando se suelta el clic derecho
    if (Input.GetMouseButtonUp(1))
    {
        isAiming = false;
        animar.SetBool("Aim", false);
    }


    if (Input.GetButtonDown("Fire1") && single)
    {
        StartCoroutine(Disparo());
        Debug.Log("disparo");
    }
                      
}


     IEnumerator Disparo()
    {
        RaycastHit hit;
        bool hitInfo = Physics.Raycast(firePoint.position, firePoint.forward, out hit, 50f);

        if (hitInfo)
        {
            Enemigos enemigo = hit.transform.GetComponent<Enemigos>();

            if (enemigo != null)
            {
                Debug.Log("Enemigo Impactado");
                enemigo.takeDamege(damage);
                Instantiate(bloodFX, hit.point, Quaternion.identity);
            }

            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, hit.point);

        }
        else
        {
            lineRenderer.SetPosition(0, firePoint.position);
            lineRenderer.SetPosition(1, firePoint.position + firePoint.forward * 20);
        }

        shootFX.SetActive(true);
        lineRenderer.enabled = true;
        Instantiate(casquillo, casketPoint.position, casketPoint.rotation);

        yield return new WaitForSeconds(0.04f);
        shootFX.SetActive(false);
        lineRenderer.enabled = false;


    }

}
