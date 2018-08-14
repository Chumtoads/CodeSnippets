using UnityEngine;
using System.Collections;

public class Ward : MonoBehaviour {

	public Rigidbody2D wardprefab;
	public float wardtimer = 1f;
	public float wardMultiplier = 0.01f;
	public float decayMultiplier = 0f;
	public Vector3 maxWardSize;
	private bool isCharging;
	private float chargingLight = 0f;
	private float decayLight = 0f;
	private bool startDecay = false;
	void Update () 
	{

		
		if (Input.GetMouseButton (0)) 
		{
			chargingLight += Time.deltaTime;
			if (chargingLight > 1 && transform.localScale.magnitude<maxWardSize.magnitude) {
				isCharging = true;
				gameObject.transform.localScale+=new Vector3(wardMultiplier, wardMultiplier, wardMultiplier);
				Debug.Log ("chargeattack");
			}
		}
		
		if (Input.GetMouseButtonUp(0)) 
		{
			wardDestroy();
			startDecay = true;
		}

		if (startDecay) 
		{
			decayLight += Time.deltaTime;
			if (decayLight>1 && gameObject.transform.localScale.magnitude > 0)
			{
				gameObject.transform.localScale -= new Vector3(decayMultiplier, decayMultiplier, decayMultiplier);
			}
		}

	}
	
	void wardDestroy(){
		wardtimer = (transform.localScale.magnitude*10);
		Destroy (gameObject, wardtimer);
	}
}
