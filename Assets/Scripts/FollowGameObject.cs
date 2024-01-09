using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowGameObject : MonoBehaviour
{
	public string gameObjectTag;
	private GameObject objectToFollow;
	public float speed = 2f;
	public float stoppingDistance = 1f;
	private Animator ottoAnim;
    // Start is called before the first frame update
    void Start()
    {
     	objectToFollow = GameObject.FindGameObjectWithTag(gameObjectTag);   
     	ottoAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null){

        	if (Vector3.Distance(transform.position, objectToFollow.transform.position) > stoppingDistance){
				ottoAnim.SetBool("IsFloating",true);
				Vector3 tempPos = objectToFollow.transform.position;
				tempPos.y = 0;
				transform.position = Vector3.MoveTowards (transform.position, tempPos, speed*Time.deltaTime);
		        
		        var lookPos = objectToFollow.transform.position - transform.position;
				lookPos.y = 0;
				var rotation = Quaternion.LookRotation(lookPos);
				transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f); 
	        } else {
	        	ottoAnim.SetBool("IsFloating",false);
	        }
        }
    }
}
