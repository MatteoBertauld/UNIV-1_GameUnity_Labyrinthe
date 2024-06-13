using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ChangeLab;

public class red : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer unRendu = GetComponent<Renderer>();
        if (unRendu!=null)  
        {
            if(count == 2) {   unRendu.enabled = true;}
            else {unRendu.enabled = false;} 
        }
    }
}
