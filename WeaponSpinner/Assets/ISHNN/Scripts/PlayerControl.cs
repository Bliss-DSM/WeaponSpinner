using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    [SerializeField]private float move_speed = 30; //이동속도
    [SerializeField]private float look_speed = 3;  //선회속도
    [SerializeField] private float jump_power = 5; //점프력

    private Rigidbody p_rigidbody;
    private Animator anim;

    private Vector3 targetPosition;
    private Vector3 lookPosition;

    private void Awake()
    {
        p_rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	void Update () {
        Walk();
    }
    
    void Walk()
    {
        if (Input.anyKey)
        {
            //키보드 입력 받고 타겟 포지션 선정
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

            //포지션으로 이동
            //transform.position += targetPosition * move_speed * Time.deltaTime;
            p_rigidbody.AddForce(targetPosition * move_speed, ForceMode.Impulse);

            //타겟 포지션 쪽으로 천천히 선회
            transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.LookRotation(targetPosition), Time.fixedDeltaTime * look_speed);

            //점프
            if (Input.GetKeyDown(KeyCode.Space))
            {
                p_rigidbody.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
            }
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
