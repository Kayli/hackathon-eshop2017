using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startup : MonoBehaviour
{
    private Rigidbody _ground;

    // Use this for initialization
    void Start () {
        _ground = GameObject.Find("ground").GetComponent<Rigidbody>();

        Application.ExternalCall("OnUnityLoaded");
        //ShowProduct("{\"shape\" : \"cylinder\", \"color\" : \"red\"}");
    }
	
	  // Update is called once per frame
	  void Update () { }

    public void ShowProduct(string json)
    {
        var productParameters = JsonUtility.FromJson<ProductParameters>(json);
        
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

        switch (productParameters.shape)
        {
            case "box":
                productShape = PrimitiveType.Cube;
                break;
            case "cylinder":
                productShape = PrimitiveType.Cylinder;
                break;
            case "sphere":
                productShape = PrimitiveType.Sphere;
                break;
        }

        var gameObject = GameObject.CreatePrimitive(productShape);
        gameObject.name = name;
        gameObject.transform.position = new Vector3(0.51f, 1.96f, -0.1f); 
        var renderer = gameObject.GetComponent<Renderer>();
        renderer.material = new Material(Shader.Find("Standard")) { color = productColor };
        var rigidbody = gameObject.AddComponent<Rigidbody>();
        if (productShape == PrimitiveType.Cylinder)
        {
            Destroy(gameObject.GetComponent<CapsuleCollider>());
            gameObject.AddComponent<BoxCollider>();
        }
        
        //spin ground around Y axis, so that we can see object from different angles
        _ground.AddTorque(Vector3.up * 30f, ForceMode.Acceleration);
    }
}

[Serializable]
public class ProductParameters
{
    public string color;
    public string shape;
}
