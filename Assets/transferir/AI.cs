using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AI : MonoBehaviour {

    public Vector3 atual;
    public Vector3 próximo;

    public Vector3 frente; 
    public Vector3 direita;
    public Vector3 frente2;
    public Vector3 esquerda;

	void Start () {
       frente = new Vector3 (0,0,24);
        direita = new Vector3();
    }
	
	void Update () { 
        for (int i = 1; i < 50; i++) {
            próximo.z = atual.z + frente.z;
            StartCoroutine(TempoReacao());
            próximo.x = atual.x + esquerda.x;
            StartCoroutine(TempoReacao());
            próximo.z = atual.z + frente2.z;
            StartCoroutine(TempoReacao());
            próximo.x = atual.x + direita.x;
            StartCoroutine(TempoReacao());
        }
    }

    IEnumerator TempoReacao()
    {
        yield return new WaitForSeconds(5);
    }
}