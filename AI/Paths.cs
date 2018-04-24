using UnityEngine;
using System.Collections;

public class Paths : MonoBehaviour {
    private Creinno.Vertex CurrentPoint;
    public Creinno.Vertex[] pathsChilds;


	// Use this for initialization
	void Awake () {

        pathsChilds = GetComponentsInChildren<Creinno.Vertex>();
        EmplyPoints();
    }
	
	// Update is called once per frame
	void Update () {
        MoveCarEnemy();

    }
    void MoveCarEnemy()
    {

    }

    void EmplyPoints()
    {
        int length = pathsChilds.Length;
        for (int i = 1; i < length - 1; i++)
        {
            pathsChilds[i].NextPoint     = pathsChilds[i + 1];
            pathsChilds[i].PreviousPoint = pathsChilds[i - 1];
        }
        pathsChilds[0].NextPoint = pathsChilds[1];
        pathsChilds[0].PreviousPoint = pathsChilds[length - 1];
        pathsChilds[length-1].NextPoint = pathsChilds[0];
        pathsChilds[length-1].PreviousPoint = pathsChilds[length-2];
    }
}
