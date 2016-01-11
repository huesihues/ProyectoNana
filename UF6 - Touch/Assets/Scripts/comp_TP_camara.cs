using UnityEngine;
using System.Collections;

public class comp_TP_camara : MonoBehaviour {

	public Transform cameraTarget;

	//posicion

	public float mouseY;
	public float mouseX;
	public float minMouseY;
	public float maxMouseY;

	//sensibilidad

	public float X_MouseSensibility;
	public float Y_MouseSensibility;

	//distancia con el objetivo
	public float Distance;
	public float Maxdistance;
	public float Mindistance;
	public float DesiredDistance;
	private float VelDistance;
	public float smoothDistanceTime;

	private Vector3 desiredPosition ;
	public float WHEEL_SENSIVITY;





	// Use this for initialization
	void Start () 
	{
		minMouseY = -20.0f;
		maxMouseY = 80.0f;
		VelDistance = 0.0f;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
				if (cameraTarget == null) {
						return;
				}
		handleInput ();
		calculateDesiredPosition();
		updateCameraPosition ();



	}
	private void updateCameraPosition()
	{
		transform.position = desiredPosition;
		transform.LookAt (cameraTarget );


	}
	private void handleInput()
	{
		if (Input.GetMouseButton (0) && !Input.GetMouseButton (1)) 
		{
			mouseX+=Input.GetAxis ("Mouse X")*X_MouseSensibility ;
			mouseY-=Input.GetAxis ("Mouse Y")*Y_MouseSensibility ;

		}

		if (Input.GetAxis ("Mouse ScrollWheel") < - 0.01f || Input.GetAxis ("Mouse ScrollWheel") > 0.01f) 
		{
			DesiredDistance =Distance-Input.GetAxis ("Mouse ScrollWheel")*WHEEL_SENSIVITY;
			DesiredDistance = Mathf.Clamp(DesiredDistance,Mindistance,Maxdistance);


		}
		if (Input.GetMouseButtonDown (1))
		{
			Transform playerTransform=GameObject.Find ("SimpleTPCharacter").GetComponent<Transform>();
			playerTransform.rotation=transform.rotation;


		}
		if (Input.GetMouseButton (1))
		{
			Transform playerTransform=GameObject.Find ("SimpleTPCharacter").GetComponent<Transform>();
			mouseX+=Input.GetAxis ("Mouse X")*X_MouseSensibility;
			mouseY-=Input.GetAxis ("Mouse Y")*Y_MouseSensibility;

			float angle =playerTransform.rotation.eulerAngles.y;
			Quaternion q = Quaternion.Euler (0,angle+Input.GetAxis ("Mouse X")*X_MouseSensibility,0);
			playerTransform.rotation = q;
			
			
		}

		mouseY = Mathf.Clamp (mouseY, minMouseY, maxMouseY);



	}
	private Vector3  calculatePosition()
	{
		Vector3 direction = new Vector3 (0, 0, -Distance);
		Quaternion q = Quaternion.Euler (new Vector3 (mouseY,mouseX,0));
		return (cameraTarget.position + q * direction);

		
		
	}
	private void calculateDesiredPosition()
	{
		Distance = Mathf.SmoothDamp (Distance,DesiredDistance, ref VelDistance, smoothDistanceTime);

		desiredPosition = calculatePosition ();
	}



}
