using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitFuns : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static IEnumerator WaitAndDestroy(float TimeToDestroy , GameObject ObjectDestroy)
	{
		yield return new WaitForSeconds(TimeToDestroy);
		Destroy(ObjectDestroy);
	}
}
