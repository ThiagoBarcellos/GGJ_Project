using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanMoveTo : MonoBehaviour
{

    public int nEletrons;
    public bool canMove = false;
    public bool temElerons = false;
    Vector3 targetPosition;
    public GameObject ppotse;
   
    //public gameObject player;

    void Start()
    {
        nEletrons = 0;
        targetPosition = transform.position;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                targetPosition = hit.point;
                this.transform.position = targetPosition;
            }

        }
    }

    void OnTriggerEnter(Collider coll)
    {
        coll.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
    }

    void OnTriggerStay(Collider coll)
    {
        Debug.Log("ola");
        if (coll.tag == "habil")
        {
            Debug.Log("ola2");
            canMove = true;
            coll.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        canMove = false;
        coll.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
    }

    void OnMouseDown() {
         if (gameObject.tag == "habil") {
             //player.transform.position = vector3.lerp(player.transform.position, gameobject.transform.positions);
         }
     }
}