using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class comp_vida : MonoBehaviour 
{
		public GameObject[] digit_counters;
		public int counter_current;
		public int min_value;
		public int max_value;
		public int start_value;
		private int[] dividers = {1,10,100,1000,10000,100000};
		public int[] counter;
		private Comp_HUD_Atlas comp_HUD_atlas;
		public Comp_Player Speed;
		// Use this for initialization
		void Start ()
		{
			counter_current = start_value;
			comp_HUD_atlas = GameObject.Find ("Vidas").GetComponent<Comp_HUD_Atlas> ();
		    Speed = GameObject.Find ("Player").GetComponent<Comp_Player> ();
		}
		
		// Update is called once per frame
		void Update () 
		{
			int Vida1 = counter [0];
			int Vida2 = counter [1];
			int Vida3 = counter [2];
		
			
			digit_counters[0].GetComponent<Image>().sprite=comp_HUD_atlas.sprites[Vida1]  ;
			digit_counters[1].GetComponent<Image>().sprite=comp_HUD_atlas.sprites[Vida2]  ;
			digit_counters[2].GetComponent<Image>().sprite=comp_HUD_atlas.sprites[Vida3]  ;
		
			computeCounter ();
			
		}
		private void computeCounter ()
		{
			int aux = counter_current;
			if (aux == 1)
		{
			counter [0] = 1;
		}
		if (aux == 2)
		{
			counter [1] = 1;
		}
		if (aux == 3)
		{
			counter [2] = 1;
		}
		if (aux == 4)
		{
			Debug.Log ("Que manco xD");
			Speed.SPEED=0;
		}
				
			
		}
	}
