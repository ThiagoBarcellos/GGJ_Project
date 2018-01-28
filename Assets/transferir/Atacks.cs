using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacks : MonoBehaviour {

	RaycastHit hit;
	Ray ray;

	public GameObject saida;
	public GameObject alvo;

	bool check;
	bool ataque;

	void Start ()
	{
		
	}
	
	void Update () 
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if(Physics.Raycast(ray, out hit))
		{
			if (hit.collider.gameObject.tag == "Poste" || hit.collider.gameObject.tag == "Central") {
				if (Input.GetMouseButtonDown (0)) {
					if (hit.collider.GetComponent<PosteBehaviour> ().produzindo && 
						hit.collider.GetComponent<PosteBehaviour> ().eletrons > 5 &&
						hit.collider.GetComponent<PosteBehaviour> ().controleBase == "Amigo") {
						saida = hit.collider.gameObject;
					}
				}
				if (Input.GetMouseButtonUp (0)) {
					alvo = hit.collider.gameObject;
					check = true;
				}
			}
		}

		if (check) {
			for (int x = 0; x < saida.GetComponent<PosteBehaviour> ().postesPerto.Count; x++) {
				if (saida.GetComponent<PosteBehaviour> ().postesPerto [x].name == alvo.name) {
					ataque = true;
				}
			}
		}

		if (ataque) {
			switch (alvo.GetComponent<PosteBehaviour> ().controleBase) {
			case "Amigo":
				saida.GetComponent<PosteBehaviour> ().eletrons -= 5;
				alvo.GetComponent<PosteBehaviour> ().eletrons += 5;
				check = false;
				ataque = false;
				break;
			case "Neutro":
				saida.GetComponent<PosteBehaviour> ().eletrons -= 5;
				alvo.GetComponent<PosteBehaviour> ().controleBase = "Amigo";
				alvo.GetComponent<PosteBehaviour> ().eletrons += 1;
				alvo.GetComponent<PosteBehaviour> ().produzindo = true;
				check = false;
				ataque = false;
				break;
			case "Inimigo":
				saida.GetComponent<PosteBehaviour> ().eletrons -= 5;
				alvo.GetComponent<PosteBehaviour> ().eletrons -= 5;
				if (alvo.GetComponent<PosteBehaviour> ().eletrons < 0) {
					alvo.GetComponent<PosteBehaviour> ().controleBase = "Amigo";
					alvo.GetComponent<PosteBehaviour> ().eletrons *= -1;
				}
				if (alvo.GetComponent<PosteBehaviour> ().eletrons == 0) {
					alvo.GetComponent<PosteBehaviour> ().controleBase = "Neutro";
				}
				check = false;
				ataque = false;
				break;
			}
		}
	}
}