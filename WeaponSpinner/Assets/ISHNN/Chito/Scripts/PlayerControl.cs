using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float move_speed = 30;
    public float look_speed = 3;

    public Rigidbody p_rigidbody;

    Vector3 targetPosition;
    Vector3 lookPosition;

    Animator anim;


    private void Awake()
    {
        p_rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Walk();
    }
    
    void Walk()
    {
        if (Input.anyKey)
        {
            targetPosition = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                targetPosition += Vector3.forward;
                anim.SetBool("isWalking", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                targetPosition += Vector3.forward * -1;
                anim.SetBool("isWalking", true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                targetPosition += Vector3.right * -1;
                anim.SetBool("isWalking", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                targetPosition += Vector3.right;
                anim.SetBool("isWalking", true);
            }

            targetPosition.y = 0;
            //transform.position += targetPosition * move_speed * Time.deltaTime;
            p_rigidbody.AddForce(targetPosition * move_speed, ForceMode.Impulse);

            transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(targetPosition), Time.fixedDeltaTime * look_speed);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                p_rigidbody.AddForce(Vector3.up * 1000, ForceMode.Impulse);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
