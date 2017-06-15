using System;
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

        

        _product.GetComponent<MeshRenderer>().enabled = false;
        Application.ExternalCall("OnUnityLoaded");
    }
	
	  // Update is called once per frame
	  void Update ()
	  {
        var speed = 30;
        //_ground.gameObject.transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }

    public void ShowProduct(string json)
    {
        var productParameters = JsonUtility.FromJson<ProductParameters>(json);
        var renderer = _product.GetComponent<Renderer>();
        var productColor = Color.red;
        var productShape = PrimitiveType.Cylinder;
        switch (productParameters.color)
        {
          case "red": 
            productColor = Color.red;
            break;
          case "black":
            productColor = Color.black;
            break;
          case "white":
            productColor = Color.white;
            break;
        }
        renderer.material = new Material(Shader.Find("Standard")) { color = productColor };

        //spin ground around Y axis, so that we can see object from different angles
        _ground.AddTorque(Vector3.up * 30f, ForceMode.Acceleration);

        //show product
        _product.GetComponent<MeshRenderer>().enabled = true;
    }
}

[Serializable]
public class ProductParameters
{
    public string color;
    public string shape;
}
