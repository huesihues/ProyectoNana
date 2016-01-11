using UnityEngine;
using System.Collections;

public class comp_Cogevida : MonoBehaviour {

	public Vector3 axis = Vector3.zero;
	public float angular_speed = 90;
	//public comp_vida Vida;
	public Comp_Player player;
	void Start () 
	{
		//Vida = GameObject.Find ("Vidas").GetComponent<comp_vida> ();
		player = GameObject.Find ("Player").GetComponent<Comp_Player> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Rotate (axis * angular_speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider collider)
	{
	
		if (player.vida <3) 
		{
			player.vida=player.vida+1;
			Destroy (gameObject);
		}
	}
}
