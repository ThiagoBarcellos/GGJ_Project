using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PosteBehaviour : MonoBehaviour {

	public List<Transform> postesPerto = new List<Transform>();

	public bool produzindo;
	public string controleBase;
	public int eletrons;
	int limite;

	float TempoProducao;
	float CDProducao = 0f;

	TextMesh meusEletrons;

	public bool selected;
	public Transform alvo;
	int clicks;

	void Start ()
	{
		switch (gameObject.tag) {
		case "Poste":
			TempoProducao = 1.5f;
			limite = 20;
			break;
		case "Central":
			TempoProducao = 0.5f;
			limite = 40;
			break;
		}

		meusEletrons = gameObject.GetComponentInChildren<TextMesh> ();
	}
	
	void Update ()
	{
		if (produzindo && eletrons < limite) {
			CDProducao += 1f * Time.deltaTime;
			if (CDProducao > TempoProducao) {
				eletrons += 1;
				CDProducao = 0;
			}
		}
			
		meusEletrons.text = eletrons.ToString();
		switch (controleBase) {
		case "Amigo":
			meusEletrons.color = Color.red;
			break;
		case "Inimigo":
			meusEletrons.color = Color.blue;
			break;
		case "Neutro":
			meusEletrons.color = Color.gray;
			break;
		}
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Poste")
			postesPerto.Add (col.transform);
        if (col.tag == "Player2") {
            controleBase = "Inimigo";
        }
	}
}
