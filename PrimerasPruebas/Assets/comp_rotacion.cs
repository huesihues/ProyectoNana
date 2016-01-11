using UnityEngine;
using System.Collections;

public class comp_rotacion : MonoBehaviour {

	//public Quaternion lRight;
	//public Quaternion lLeft;
	public Comp_Player player;
	public float rotacionI;
	public float rotacionD;
	public float rotationSpeed;
	public float rot;

	// Use this for initialization
	void Start () 
	{
		//rotation = transform.rotation;
		player = GameObject.Find ("Player").GetComponent<Comp_Player> ();


	}
	
	// Update is called once per frame
	void Update () 
	{
		rot = transform.rotation.y;
		//Debug.Log (transform.rotation.y);
		/*if (Input.GetKeyDown ("a")&& player.mirandoDerecha== true) 
		{
			transform.rotation=Quaternion.Lerp (transform.rotation,lLeft,Time.deltaTime);
		}
		if (Input.GetKeyDown ("d")&& player.mirandoDerecha== false) 
		{
			transform.rotation=Quaternion.Lerp (transform.rotation,lRight,5f);
			Debug.Log("ddd");
		}*/
		//&& player.mirandoDerecha== false

		if (Input.GetKey("a")  && transform.rotation.y <= rotacionI)
		{
			transform.Rotate(transform.up, 90 * rotationSpeed * Time.deltaTime);
		}
		else
		{
			if (Input.GetKey("d")&& transform.rotation.y > rotacionD)
			{
				transform.Rotate(transform.up, -90 * rotationSpeed* Time.deltaTime);
			}
		}
	}
}
