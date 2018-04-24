using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Shooting : MonoBehaviour
{
    public GameObject FxWeaponRocket;
    public GameObject rocket;
    public GameObject InstantiateObjPositionRocket;
    public byte NbOfRockets = 3;
    public Text NbRockets;

    /*
    public GameObject FxWeaponBullet;
    public GameObject bullet;
    public GameObject InstantiateObjPositionBullet;
    */
    public float DeltaShooting = 0.1f;


    // Use this for initialization
    void Start()
    {

        NbRockets.text = NbOfRockets.ToString();
        // StartCoroutine(WaitAndShooting(DeltaShooting));

    }

    IEnumerator WaitAndShooting(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        StartCoroutine(WaitAndShooting(DeltaShooting));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Launching()
    {

        if (NbOfRockets > 0 && Time.timeScale != 0)
        {
            NbOfRockets--;
            NbRockets.text = NbOfRockets.ToString();

            //FxWeaponRocket.SetActive(true);

            Instantiate(rocket, InstantiateObjPositionRocket.transform.position, InstantiateObjPositionRocket.transform.rotation);
            //Instantiate(FxWeaponRocket, InstantiateObjPositionRocket.transform.position, InstantiateObjPositionRocket.transform.rotation);

        }

    }

}