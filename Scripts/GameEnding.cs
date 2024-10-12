using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float fadederation = 1f;
    public float showimagederation = 1f;
    bool playeratexit;
    bool playercaught;
    float timer;
    public GameObject player;
    public CanvasGroup exitbackgroundimage;
    public CanvasGroup caughtbackgroundimage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(playeratexit == true){
           EndLevel(exitbackgroundimage, true);
       } 
       if(playercaught == true){
           EndLevel(caughtbackgroundimage, true);
       }
    }
    void OnTriggerEnter(Collider c){
        if(c.gameObject == player){
            playeratexit = true;
        }
        
    }
    void EndLevel(CanvasGroup ending, bool restart){
        timer += Time.deltaTime;
        ending.alpha=timer/fadederation;
        if(timer>fadederation+showimagederation){
            if(restart==true){
                SceneManager.LoadScene(0);
            }else{
            Application.Quit();
            }


        }
    }
    public void caughtplayer(){
        playercaught = true;
    }
}
