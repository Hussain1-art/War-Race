using UnityEngine;
using System.Collections;

public class MoveCarRobot : MonoBehaviour {

    // public Transform positionPath;
    public Creinno.Vertex Goal;
	public float speed = 0.0f;

	public Transform vRight;
	private CarControlCS target;
    // Use this for initialization
    void Awake () {
		target = GetComponent<CarControlCS>();

		// StartCoroutine (WaitAndSteer());
    }
	

	// Update is called once per frame
    void FixedUpdate()
    {
		
        ControllerSpeed();

		float Angle = MathsFuns.calculateAngleThreePoint (transform.position, vRight.position, Goal.transform.position);
		if ((Angle < 85 && Angle > -85) || (Angle > 95)) {
			ControllerSteer ();
		}
    }

	void ControllerSteer (){
		
		float angle = MathsFuns.calculateAngleThreePoint (transform.position, vRight.position, Goal.transform.position);

		if (angle <= 90) {
			target.setSteerInput ( 1);
		} else {
			target.setSteerInput (-1);

		}
	}

    /*
	IEnumerator WaitAndSteer (){
		yield return new WaitForSeconds (0.5f);
		ControllerSteer ();
		StartCoroutine (WaitAndSteer());
	}
	*/

    void ControllerSpeed()
    {
		
		if (target.getCurrentSpeed () < speed) {
			target.setThrottleInput ( 1);
		} else {
			target.setThrottleInput (-1);
		}
        
    }
    
}
