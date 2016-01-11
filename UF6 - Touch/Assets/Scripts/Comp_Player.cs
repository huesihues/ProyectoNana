using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comp_Player : MonoBehaviour
{
	//Movimiento
	private CharacterController cc;
	public float vida;
	public float SPEED;
	public float BaseSpeed;
	public float JSPEED;
	public float Gravity;
	public bool Grounded;
	public Vector3 cc_velocity;
	public float saltoDoble;

	//dash
	public float DashSpeed;
	public float timeDash;
	public bool CoolDownDash=false;
	public Image AvariableDash;

	//Vida

	public Image vida1;
	public Image vida2;
	public Image vida3;

	public Sprite VidaLlena;
	public Sprite VidaVacia;

    //particulas
    public ParticleSystem particulasAire;
    public ParticleSystem particulasAire2;

	//animaciones
	public bool mirandoDerecha=true;
	public Animator preAnimator;

    void Start ()
	{

		AvariableDash = GameObject.Find ("DashLleno").GetComponent<Image> ();
        particulasAire = GameObject.Find("ParticulasSalto").GetComponent<ParticleSystem>();
        particulasAire2 = GameObject.Find("ParticulasSalto2").GetComponent<ParticleSystem>();
        Grounded = false;
		cc_velocity = Vector3.zero;
		cc = GetComponent<CharacterController> ();
//		Vidas = GameObject.Find ("Vidas").GetComponent<comp_vida> ();
		timeDash = 0;
		SPEED = BaseSpeed;
		vida = 3;

	}
	
	// Update is called once per frame
	void Update ()
	{
		Grounded = cc.isGrounded;
		if (Grounded)
		{
			cc_velocity.y = -1;
			saltoDoble=0;
		}

		handleTouchInput();
		//gestorDeVida
		GestorDeVida ();
		//gestorRotacion
		GestorDeRotacion ();
		//movimiento
		Vector3 movement = Vector3.zero;

		if (Input.GetKey ("d") ||(Input.GetKey(KeyCode.RightArrow)) ) 
		{
			movement = transform.forward * SPEED * Time.deltaTime;
		}
		if (Input.GetKey("a") || (Input.GetKey(KeyCode.LeftArrow))) 
		{
			movement = transform.forward * SPEED * -1 * Time.deltaTime;
		}

		Dash ();

		// calculo gravedad
		movement.y = cc_velocity.y * Time.deltaTime  
			+ 0.5f * Gravity * Time.deltaTime * Time.deltaTime;

		// la velocidad va cambiando a cada frame
		cc_velocity.y = cc_velocity.y + Gravity * Time.deltaTime;

		cc.Move(movement);

		// muerte
		if (transform.position.y < -5) 
		{
			transform.position = new Vector3 ( 0f, 2.0446f,-17.971f );
			//Vidas.counter_current+=1;
			vida=vida-1;

		}
	}

	private void jump()
	{
		if (Grounded || saltoDoble <2)
		{
			cc_velocity.y = JSPEED;
			saltoDoble=saltoDoble+1;
            if(saltoDoble == 2)
            { 
                particulasAire.Emit(150);
                particulasAire2.Emit(350);
            }
        }
	}

	private void handleTouchInput()
	{
		if (Input.touchCount > 0)
		{
			if (Input.GetTouch(0).phase == TouchPhase.Began)
			{
				// Vale, acabamos de pulsar el touch
				jump();
			}
		}
		else
		{
			if (Input.GetKeyDown("space"))
			{
				jump ();
			}
		}
	}
	public void GestorDeVida ()
	{
		if (vida == 3) 
		{
			vida1.sprite=VidaLlena;
			vida2.sprite=VidaLlena;
			vida3.sprite=VidaLlena;
		}
		if (vida == 2) 
		{
			vida1.sprite=VidaLlena;
			vida2.sprite=VidaLlena;
			vida3.sprite=VidaVacia;
		}
		if (vida == 1) 
		{
			vida1.sprite=VidaLlena;
			vida2.sprite=VidaVacia;
			vida3.sprite=VidaVacia;
		}
		if (vida == 0) 
		{
			vida1.sprite=VidaVacia;
			vida2.sprite=VidaVacia;
			vida3.sprite=VidaVacia;
		}
		if (vida == -1) 
		{
			SPEED=0;
			JSPEED=0;
		}
	}
	public void Dash()
	{
		if (Input.GetKey(KeyCode.LeftShift)&& CoolDownDash==false) 
		{
			SPEED=DashSpeed;
			timeDash= timeDash + Time.deltaTime;
			if(timeDash>=0.2)
			{
				CoolDownDash=true;
			}
			
		}
		if (!Input.GetKey(KeyCode.LeftShift)|| CoolDownDash==true) 
		{
			SPEED=BaseSpeed;
			
		}
		if (CoolDownDash == true) 
		{
			timeDash= timeDash - Time.deltaTime * 0.04F;
			AvariableDash.color=Color.red;
			if(timeDash<=0)
			{
				CoolDownDash=false;
				AvariableDash.color=Color.green;

			}
		}

		if (timeDash < 0) 
		{
			timeDash = 0;	
		}
		else 
		{
			if(CoolDownDash==false)
			timeDash= timeDash - Time.deltaTime * 0.15F;
		}
		//indicador Dash
		/*if (CoolDownDash == false) 
		{
			AvariableDash.enabled=true;
		}
		if (CoolDownDash == true) 
		{
			AvariableDash.enabled=false;
		}*/
		AvariableDash.fillAmount= timeDash*5;
		//color




	}
	public void GestorDeRotacion ()
	{
		if (Input.GetKey ("d") || Input.GetKey ("a")) 
		{
			preAnimator.SetBool ("runing", true);
			Debug.Log ("ddd");
		} else 
		{
			preAnimator.SetBool ("runing", false);
		}
	


	
	}
}
