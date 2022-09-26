using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDeleteScript : MonoBehaviour
{
    float timeAlive = 0;
    float maxTimeAlive = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        if(timeAlive >= maxTimeAlive)
        {
            Destroy(gameObject);
        }
    }
}
