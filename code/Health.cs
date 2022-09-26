using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int health = 100;
   public void subtractHealth(int amt)
    {
        health -= amt;
        Debug.Log("Health: " + health);
        if (hasDied())
        {
            //if has died, destroy playerController component and output message
            Debug.Log("YOU DIED");
            Destroy(GetComponent<playerController>());
        }
    }

    public bool hasDied()
    {
        return (health < 0);
    }

}
