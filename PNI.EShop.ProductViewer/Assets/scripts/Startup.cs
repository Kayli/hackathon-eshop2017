using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    private Rigidbody _product;
    private Rigidbody _ground;

    // Use this for initialization
    void Start () {
        _product = GameObject.Find("product").GetComponent<Rigidbody>();
        _ground = GameObject.Find("ground").GetComponent<Rigidbody>();
        _ground.AddTorque(Vector3.up * 30f, ForceMode.Acceleration);
    }
	
	// Update is called once per frame
	void Update ()
	{
	    

        var speed = 30;
        //_ground.gameObject.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
