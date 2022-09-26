using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField]Transform L, R;
    [SerializeField] float t = 0.5f;
    float multiplier = 1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        //check collisions
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().subtractHealth(49);
        }
        else if(collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * multiplier;//add to interpolation value
        if(t > 1 || t < 0)
        {
            multiplier *= -1;//if interpolation value is >1 or <0, swap the multiplier so it can add or subtract
        }
        //LERP
        transform.position = Vector3.LerpUnclamped(L.position, R.position, t);
    }
}
