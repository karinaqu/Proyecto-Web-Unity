using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour {
	public Transform desde;
	public Transform hasta;
	public float velocidad;
	bool ir;
	// Use this for initialization
	void Start () {
		ir = true;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 objetivo;
		if (ir) {
			objetivo = hasta.position;
		} else {
			objetivo = desde.position;
		}
		Vector3 distancia = objetivo - transform.position;
		Vector3 desplazamiento = distancia.normalized * velocidad * Time.deltaTime;
		if(desplazamiento.sqrMagnitude>= distancia.sqrMagnitude){
			desplazamiento = distancia;
			ir = !ir;
		}
		transform.position = transform.position + desplazamiento;
	}
}
