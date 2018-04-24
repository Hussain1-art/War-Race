using UnityEngine;
using System.Collections;


public class Bullet : Shoot
{

    // Use this for initialization
    void Start()
    {
        // StartCoroutine(WaitAndDestroy(TimeToDestroyObjectIfDontTouch, gameObject));
    }

    // Update is called once per frame

    void Update()
    {
        // moveGun();
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.fInfluenceBuckshot();
            TouchObject();
        }
        else
        {
            TouchObject();
        }
    }
    */

}