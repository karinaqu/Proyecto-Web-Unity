using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControladorJugador : MonoBehaviour {
	public float velocidad=10;
	int monedas=0;
	public Text textoMonedas;
	public Text textoVictoria;
	Rigidbody miRigdBody;
	Vector3 posicionInicial;
	bool haSalido;
	public string SiguienteEscena="";

	// Use this for initialization
	void Start () {
		miRigdBody = GetComponent<Rigidbody> ();
		posicionInicial = transform.position;
		textoVictoria.enabled = false;
		haSalido = false;
		
	}
	
	// Update is called once per frame
	void Update () {
		if(!haSalido){
			float vertical = Input.GetAxis ("Vertical");
			float horizontal = Input.GetAxis ("Horizontal");
			miRigdBody.MovePosition(miRigdBody.position+ new Vector3(horizontal,0,vertical)*velocidad*Time.deltaTime);
			miRigdBody.velocity = Vector3.zero;
			miRigdBody.angularVelocity = Vector3.zero;
		}
		
	}
	void OnTriggerEnter(Collider otro){
		if (otro.CompareTag ("salida")) {
			haSalido = true;
			textoVictoria.enabled = true;
			miRigdBody.velocity = Vector3.zero;
			miRigdBody.angularVelocity = Vector3.zero;
			SceneManager.LoadScene (SiguienteEscena);

		} else if (otro.CompareTag ("enemigo")) {
			miRigdBody.MovePosition (posicionInicial);
			miRigdBody.velocity = Vector3.zero;
			miRigdBody.angularVelocity = Vector3.zero;
			monedas = 0;
			textoMonedas.text="Total de Monedas: 0";
		} else if (otro.CompareTag ("moneda")) {
			otro.gameObject.SetActive (false);
			monedas = monedas + 1;
			textoMonedas.text = "Total de Monedas: " + monedas;
		}
			
	}
}
