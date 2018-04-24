using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public static byte NbEnemy;
    public float influenceRocket = 0.2f;
    public float influenceBullet = 0.02f;

    public Image image;
    public float percantage = 1;
    public GameObject carDestoy;

    public static List<GameObject> Enemies = new List<GameObject>();
    private int Index = 0;
    public float waitAndExplosion = 1;

    private void Start()
    {
        Enemies.Add(gameObject);
        Index = Enemy.NbEnemy;
        Enemy.NbEnemy++;
    }

    private void Update()
    {
        if (percantage <= 0)
        {
            StartCoroutine(WaitAndGameOver(waitAndExplosion));
        }
    }

    public void fInfluenceRocket()
    {
        percantage -= (ControllerPlayer.percantagePowerStrike * influenceRocket / 100);
    }

    public void fInfluenceBullet()
    {
        percantage -= (ControllerPlayer.percantagePowerStrike * influenceBullet / 100);
    }

    IEnumerator WaitAndGameOver(float wait)
    {
        yield return new WaitForSeconds(wait);
        Enemies.RemoveAt(Index);
        Enemy.NbEnemy--;
        gameOver();
        // Instantiate(carDestoy, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void gameOver()
    {
        NbEnemy--;
        if (NbEnemy <= 0)
        {
            print("Game Is Over");
        }
    }
}