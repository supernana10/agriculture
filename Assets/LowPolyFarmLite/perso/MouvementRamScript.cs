using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvementRamScript : MonoBehaviour
{
    public Transform player;
    public Transform playerCam;
    public float throwForce=10;
    private bool hashPlayer = false;
    private bool beingCarried = false;
    private bool touched= false;

    // Start is called before the first frame update
  /*   void Start()
    {
        
    } */

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(gameObject.transform.position,player.position);
         if (dist <= 1.9f){
              hashPlayer = true;
         }
         else
         {
             hashPlayer = false;
         }
         if (hashPlayer && Input.GetKey(KeyCode.E)){
             GetComponent<Rigidbody>().isKinematic = true;
             transform.parent =playerCam;
             beingCarried =true;
         }
         if (beingCarried){
             if(touched){
                  GetComponent<Rigidbody>().isKinematic = false;
                  transform.parent =null;
                  beingCarried =false;
                  touched= false;
             }
             if(Input.GetMouseButtonDown(0)){
                 GetComponent<Rigidbody>().AddForce(playerCam.forward* throwForce);
             }
             else if(Input.GetMouseButtonDown(1)){
                    GetComponent<Rigidbody>().isKinematic = false;
                  transform.parent =null;
                  beingCarried =false; 
             }
         }
    }
    void OnTriggerEnter() {
        if(beingCarried){
            touched = true;  
        }
    }
}
