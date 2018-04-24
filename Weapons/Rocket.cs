using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rocket : MonoBehaviour
{

    public GameObject FXTouch;
    public GameObject Body;

    public float influence = 0.05f;
    public int TimeToDestroyObjectIfTouch = 1;
    public int TimeToDestroyObjectIfDontTouch = 5;
	
    public float speedRocket = 1;
    public float angMax = 3f;
    private Vector3 pEnemy;
	private int indexEnemyGoal;

        // Use this for initialization
    void Start()
	{
		indexEnemyGoal = -1;

		if (Enemy.Enemies.Count >= 0) {
				
			for (int i = 0; i < Enemy.Enemies.Count; i++) {
				float ang = MathsFuns.calculateAngleThreePoint (transform.position, transform.position + transform.forward, Enemy.Enemies [i].transform.position);

				if (Mathf.Abs (angMax) > Mathf.Abs (ang)) {
					indexEnemyGoal = i;
					break;
				}
			}

		}

		StartCoroutine (WaitFuns.WaitAndDestroy (TimeToDestroyObjectIfDontTouch, gameObject));
	}

        // Update is called once per frame
    void Update()
	{
		MoveRocket ();
    }

		
	protected  void MoveRocket ()
	{
		if (indexEnemyGoal != -1) {
			
			speedRocket += 0.1f;
			transform.position = Vector3.Lerp (transform.position, Enemy.Enemies [0].transform.position, Time.deltaTime * speedRocket);
			transform.rotation = Quaternion.Lerp (transform.rotation, Enemy.Enemies [0].transform.rotation, Time.deltaTime * speedRocket);

		} else {
			
			transform.transform.position += (speedRocket * speedRocket) * Time.deltaTime * transform.forward;

		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {

            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.fInfluenceRocket();
            
        }

        TouchObject();
    }

    // Functions TouchObject
    private void TouchObject()
    {
        FXTouch.SetActive(true);
        WaitFuns.WaitAndDestroy(1f, gameObject);
        Destroy(Body);
        Destroy(this);
    }

}