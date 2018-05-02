using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    [SerializeField]private float move_speed = 1; //이동속도
    [SerializeField]private float look_speed = 0.2f;  //선회속도
    [SerializeField] private float jump_power = 10; //점프력

    private Rigidbody p_rigidbody;
    private Animator anim;

    private void Awake()
    {
        p_rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
	
	private void Update () {
        Control();
    }

    private void Control()
    {
        if (Input.GetKey(KeyCode.W))
            Walk(Vector3.forward);
        if (Input.GetKey(KeyCode.S))
            Walk(Vector3.back);
        if (Input.GetKey(KeyCode.A))
            Walk(Vector3.left);
        if (Input.GetKey(KeyCode.D))
            Walk(Vector3.right);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    
    public void Walk(Vector3 TargetPos)
    {
        TargetPos.y = 0;
        //포지션으로 이동
        p_rigidbody.AddForce(TargetPos * move_speed, ForceMode.VelocityChange);

        //타겟 포지션 쪽으로 천천히 선회
        transform.rotation = Quaternion.Lerp(transform.rotation,
        Quaternion.LookRotation(TargetPos), look_speed);
    }

    public void Jump()
    {
        p_rigidbody.AddForce(Vector3.up * jump_power, ForceMode.Impulse);
    }
}
