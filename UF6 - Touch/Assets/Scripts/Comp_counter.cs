using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Comp_counter : MonoBehaviour 
{
	public GameObject[] digit_counters;
	public int counter_current;
	public int min_value;
	public int max_value;
	public int start_value;
	private int[] dividers = {1,10,100,1000,10000,100000};
	public int[] counter;
	private Comp_HUD_Atlas comp_HUD_atlas;
	// Use this for initialization
	void Start ()
	{
		counter_current = start_value;
		comp_HUD_atlas = GameObject.Find ("HUD_Atlas").GetComponent<Comp_HUD_Atlas> ();

	}
	
	// Update is called once per frame
	void Update () 
	{
		int unidades = counter [0];
		int decenas = counter [1];

		digit_counters[0].GetComponent<Image>().sprite=comp_HUD_atlas.sprites[unidades]  ;
		digit_counters[1].GetComponent<Image>().sprite=comp_HUD_atlas.sprites[decenas]  ;
		computeCounter ();
	
	}
	private void computeCounter ()
	{
		int aux = counter_current;
		for (int i = counter.Length - 1; i>=0; --i) 
		{
			counter[i]=(int)(aux/dividers[i]);
			aux =(int) aux %dividers[i];

		}

	}
}
