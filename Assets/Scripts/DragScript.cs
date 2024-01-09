using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
	private Animator ottoAnim;

    // Start is called before the first frame update
    void Start()
    {
        ottoAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0){
     		Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
     
	     	if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved){
		         ottoAnim.SetBool("IsFloating",true);
		         // get the touch position from the screen touch to world point
		         Vector3 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
		         // lerp and set the position of the current object to that of the touch, but smoothly over time.
		         transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
     		} else {
     			ottoAnim.SetBool("IsFloating",false);
     		}
 		}
    }
}
