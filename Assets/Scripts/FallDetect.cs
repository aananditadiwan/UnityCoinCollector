using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetect : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player =GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if( player.transform.position.y <= -20) {
            player.transform.position = new Vector3(0,2 ,0);
            CoinCounter.coinAmount = 0;
        }
        
    }
}
