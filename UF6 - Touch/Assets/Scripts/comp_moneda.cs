using UnityEngine;
using System.Collections;

public class comp_moneda : MonoBehaviour 
{
	public Vector3 axis = Vector3.zero;
	public float angular_speed = 90;
	public Comp_counter conten;

	// Use this for initialization
	void Start () 
	{
		conten = GameObject.Find ("Counter").GetComponent<Comp_counter>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (axis * angular_speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider collider)
	{

		conten.counter_current += 1;
		Destroy (gameObject);

	}
}
