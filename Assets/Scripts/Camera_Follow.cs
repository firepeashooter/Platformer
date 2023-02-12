using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform player;
    void Start() {
        transform.position = new Vector3(0, 0, transform.position.z);
    }

    // Start is called before the first frame update
    void FixedUpdate() {

        if (player.position.x > -0.68){
            transform.position = new Vector3(player.position.x, player.position.y + 0.7f, transform.position.z);
            
        }

         
        


        

        
        
    }
}
