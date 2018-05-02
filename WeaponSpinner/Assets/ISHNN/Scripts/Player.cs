using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player instance;

    [SerializeField] private float MAX_HEALTH = 100;
    public float Health { get; private set; }

    [SerializeField] protected float disableTime = 1;
    protected WaitForSeconds wait;

    BoxCollider HitBox;
    public GameObject Weapon;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
        HitBox = GetComponent<BoxCollider>();
        wait = new WaitForSeconds(disableTime);
    }
    private void Start()
    {
        StartCoroutine("CheckOverlap");
    }

    private void OnDestroy()
    {
        instance = null;
    }

    //HitBox역할을 하는 코루틴이다
    protected IEnumerator CheckOverlap()
    {
        while (true)
        {
            if (Time.timeScale == 0) yield return null;

            var overlaps = Physics.OverlapBox(transform.position, HitBox.size, Quaternion.identity, 1 << 9);
            foreach(var overlap in overlaps)
            {
                if (overlap != null && !overlap.transform.parent.Equals(this.transform))
                {
                    Debug.Log(string.Format("{0} :: {1}", this.name, overlap.name));

                    //여기 무기 충돌 후 처리할 것을 넣으면 된다.

                    yield return wait;
                }
            }
            yield return null;
        }
    }
}
