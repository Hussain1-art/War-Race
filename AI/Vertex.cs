using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Creinno {
    [System.Serializable]
    public class Adjacency
    {
        public Vertex vertex;
        public float length;
    }


    public class Vertex : MonoBehaviour {

        public int DistanceChangePoint = 10;
        public int UsingMinSpeed = 10;

        public GameObject Car;
        public Vertex PreviousPoint;
        public Vertex NextPoint;
        public int MaxSpeed;
        public int MinSpeed;
        private MoveCarRobot moveCarRobot;


        public Adjacency[] adjacency;

        void Awake()
        {
            NextPoint = this.NextChild();

            PreviousPoint = this.PreviousChild();
        }

	    // Use this for initialization
        void Start()
        {



            
            moveCarRobot = Car.GetComponent<MoveCarRobot>();

            for (int i = 0; i < adjacency.Length; i++)
            {
                adjacency[i].length = Vector3.Distance(transform.position, adjacency[i].vertex.transform.position);
            }
	    }


        private Vertex NextChild()
        {
            // Check where we are
            int thisIndex = this.transform.GetSiblingIndex();

            // We have a few cases to rule out
            if (this.transform.parent == null)
                return null;

            if (this.transform.parent.childCount <= thisIndex + 1)
                return this.transform.parent.GetChild(0).GetComponent <Vertex>();
			
            // Then return whatever was next, now that we're sure it's there
            return this.transform.parent.GetChild(thisIndex + 1).GetComponent <Vertex>();
        }


        private Vertex PreviousChild()
        {
            // Check where we are
            int thisIndex = this.transform.GetSiblingIndex();

            // We have a few cases to rule out
            if (this.transform.parent == null)
                return null;

            if (thisIndex == 0)
                return this.transform.parent.GetChild(this.transform.parent.childCount - 1).GetComponent<Vertex>();

            // Then return whatever was next, now that we're sure it's there
            return this.transform.parent.GetChild(thisIndex - 1).GetComponent<Vertex>();
        }
        
        // Update is called once per frame
        void Update()
        {
            if (moveCarRobot.Goal == this)
            {
                IsUpThisPath();
                UsingCurrentSpeed();
            }
        }
        
        void UsingCurrentSpeed()
        {
            int speed = 0;
			if (Vector3.Distance(new Vector3(Car.transform.position.x,0,Car.transform.position.z), new Vector3 (transform.position.x,0,transform.position.z)) < UsingMinSpeed)
                speed = MinSpeed;
            else
                speed = MaxSpeed;
            moveCarRobot.speed = speed;
        }
        

        void IsUpThisPath()
        {
			if (Vector3.Distance(new Vector3(Car.transform.position.x,0,Car.transform.position.z), new Vector3 (transform.position.x,0,transform.position.z)) < DistanceChangePoint)
                moveCarRobot.Goal = NextPoint;
        }
         
    }
}