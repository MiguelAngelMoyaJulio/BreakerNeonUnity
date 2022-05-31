using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spa : MonoBehaviour
{
    [SerializeField] GameObject ball;
    [SerializeField] GameObject pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spaBall();
    }


    void spaBall(){
        if(Input.GetKeyDown(KeyCode.Y)){
            Instantiate(ball,pos.transform.position,Quaternion.identity);
        }
    }
}
