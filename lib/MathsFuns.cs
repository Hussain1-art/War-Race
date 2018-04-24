using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathsFuns : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


	}

	public static float calculateAngleThreePoint (Vector3 p0, Vector3 p1, Vector3 p2)
	{
		Vector3 v1 = (p1 - p0);
		Vector3 v2 = (p2 - p0);
		float cosx = (v1.x * v2.x + v1.z * v2.z) / (Vector3.Distance (p1, p0) * Vector3.Distance (p2, p0));

		return Mathf.Acos(cosx) * Mathf.Rad2Deg;
	}

}
