using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public int healt;

    public void takeDamege(int dmg)
    {
        healt -= dmg;

        if (healt <= 0)
        {
            Destroy(gameObject, 2f);
        }
    }

}