using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public static Player instance;

    [SerializeField]private float MAX_HEALTH = 100;

    public float Health { get; private set; }


    public GameObject Weapon;

    private void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }
    private void OnDestroy()
    {
        instance = null;
    }
}
