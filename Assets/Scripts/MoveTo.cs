using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo : MonoBehaviour {
	public Transform startMarker;
    public Vector3 endMarker;
    private float speed = 0.01F;
    private float startTime;
    private float journeyLength;
	private Vector3 _direction;
	private Quaternion _lookRotation;
    void Start() {
		journeyLength=0;
        

    }

    public void StartMove(Vector3 endPos){
		startTime = Time.time;
		endMarker=endPos;
		startMarker=this.transform;
		journeyLength = Vector3.Distance(startMarker.position, endMarker);
		Debug.Log("Journey length is "+journeyLength);

		/*//find the vector pointing from our position to the target
		Vector3 tempPos = new Vector3(transform.position.x,endMarker.y,transform.position.z);
		_direction = (endMarker - tempPos).normalized;

		//create the rotation we need to be in to look at the target
		_lookRotation = Quaternion.LookRotation(_direction);

		//rotate us over time according to speed until we are in the required rotation
		transform.rotation = Quaternion.Slerp(transform.rotation, _lookRotation, Time.deltaTime * 10f);
		*/
    }

    void Update() {
		if(journeyLength>0){
	        float distCovered = (Time.time - startTime) * speed;
	        float fracJourney = distCovered / journeyLength;
	        transform.position = Vector3.Lerp(startMarker.position, endMarker, fracJourney);
			Debug.Log("fracJ "+fracJourney);
			if(fracJourney<0.1){
				var lookPos = endMarker - transform.position;
				lookPos.y = 0;
				var rotation = Quaternion.LookRotation(lookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f); 
				Debug.Log("endmarker code "+journeyLength);
			}
			
	    }
    }
}

/*
Gameobject catObject

 catObject = Instantiate(m_catPrefab, hit.Point, Quaternion.identity,
	                    anchor.transform);

					if(catObject!=null){
						Debug.Log("CAT touched");
						catObject.GetComponent<MoveTo>().StartMove(hit.Point);
					}else{
						Debug.Log("CAT IS NULL");
					}
*/

