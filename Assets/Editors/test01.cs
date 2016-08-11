using UnityEngine;

public class test01 : MonoBehaviour
{
	// Use this for initialization
	void Start ()
	{
	    Rigidbody2D[] rigs = gameObject.GetComponentsInChildren<Rigidbody2D>();
	    Debug.Log(rigs.Length);
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    
}
