using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OttoMoveTo : MonoBehaviour {
	public Transform startMarker;
    public Vector3 endMarker;
    private float speed = 0.1F;
    private float startTime;
    private float journeyLength;

	//values for internal use
	private Quaternion _lookRotation;
	private Vector3 _direction;

	// public GameObject cameraPlayer;

	private Animator ottoAnim;

    void Start() {
		journeyLength=0;
		ottoAnim = GetComponent<Animator>();
    }
    void Update() {
		if(journeyLength>0){
	        float distCovered = (Time.time - startTime) * speed;
	        float fracJourney = distCovered / journeyLength;
	        Vector3 tempPos = endMarker; // Otto moves only on Y axis;
			tempPos.y = 0;
	        transform.position = Vector3.Lerp(startMarker.position, tempPos, fracJourney);

	        if(fracJourney<0.1){
				var lookPos = endMarker - transform.position;
				lookPos.y = 0;
				var rotation = Quaternion.LookRotation(lookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f); 
			}
	    }

		if(Vector3.Distance(startMarker.position, endMarker)<0.1){
			ottoAnim.SetBool("IsFloating",false);
		}

    }

    public void StartMove(Vector3 endPos)
    {
		ottoAnim.SetBool("IsFloating",true);
    	startMarker= this.transform;
		endMarker = endPos;
		startTime = Time.time;
        journeyLength = Vector3.Distance(startMarker.position, endMarker);
        Debug.Log("Start movejourneyLength is "+journeyLength);
    }
}
