using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomOnClick : MonoBehaviour
{
	private AudioSource a_source;
    public AudioClip[] a_clips;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        a_source = gameObject.AddComponent<AudioSource>();
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
{
    if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
    {
        Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit raycastHit;
        if (Physics.Raycast(raycast, out raycastHit))
        {
            Debug.Log("Something Hit");
            
            if (raycastHit.collider.CompareTag("Zentree"))
            {
                Debug.Log("Zentree clicked");
            }
        }
    }
}

    public void OnMouseDown()
     {
         int clipPick = Random.Range(0, a_clips.Length);
         GetComponent<AudioSource>().clip = a_clips[clipPick];
         GetComponent<AudioSource>().Play();

         anim.Play("Talking");
     }
}
