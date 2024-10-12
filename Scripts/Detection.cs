using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Transform player;
    bool playerinrange;
    public GameEnding gameending;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other){
        if(other.transform == player){
            playerinrange = true;
            
        }
    }

    // Update is called once per frame
    void OnTriggerExit(Collider other){
        if(other.transform == player){
            playerinrange = false;
        }
    }
    void Update(){
        if(playerinrange == true){
            Vector3 direction = player.position - transform.position + Vector3.up;
            Ray raycast = new Ray(this.transform.position,direction);
            RaycastHit raycasthit;
            if(Physics.Raycast(raycast, out raycasthit)){
                if(raycasthit.collider.transform == player){
                    gameending.caughtplayer();
                }
            }
        }
    }
}
