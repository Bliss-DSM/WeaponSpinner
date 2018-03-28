using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    public float move_speed = 30;
    public float look_speed = 3;

    public Rigidbody p_rigidbody;

    public Camera p_camera;

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
        Look();
    }

    void Look()
    {
        lookPosition = Camera.main.transform.forward;
        lookPosition.y = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(lookPosition), Time.fixedDeltaTime * look_speed);
    }

    void Walk()
    {
        if (Input.anyKey)
        {
            targetPosition = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                targetPosition += Camera.main.transform.forward;
                anim.SetBool("isWalking", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                targetPosition += Camera.main.transform.forward * -1;
                anim.SetBool("isWalking", true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                targetPosition += Camera.main.transform.right * -1;
                anim.SetBool("isWalking", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                targetPosition += Camera.main.transform.right;
                anim.SetBool("isWalking", true);
            }

            targetPosition.y = 0;
            //transform.position += targetPosition * move_speed * Time.deltaTime;
            p_rigidbody.AddForce(targetPosition * move_speed, ForceMode.Impulse);

            if (Input.GetKey(KeyCode.Space))
            {
                p_rigidbody.AddForce(Vector3.up * 25, ForceMode.Impulse);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
