using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLab : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 1;
        for(int i=2;i<=3;i++) 
            {
                GameObject[] objetsWithTag = GameObject.FindGameObjectsWithTag("labyrinthe" + i);

                foreach (GameObject obj in objetsWithTag) 
                {
                    Renderer[] rendus = obj.GetComponentsInChildren<Renderer>();
                    foreach (Renderer unRendu in rendus) 
                    {
                        unRendu.enabled = false;                       
                    }
                    Collider colision = obj.GetComponent<Collider>();
                    if (colision != null) {
                        colision.enabled = false;
                    }

                }
            }
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Backspace)) 
        {
            count +=1;
            if(count >2) 
            {
                count = 1;
            }
            for(int i=1;i<=2;i++) 
            {
                GameObject[] objetsWithTag = GameObject.FindGameObjectsWithTag("labyrinthe" + i);

                foreach (GameObject obj in objetsWithTag) 
                {
                    Renderer[] rendus = obj.GetComponentsInChildren<Renderer>();
                    foreach (Renderer unRendu in rendus) 
                    {
                        if (i == count) 
                        {
                            unRendu.enabled = true;
                        }
                        else 
                        {
                            unRendu.enabled = false;
                        }  
                    }
                    
                    Collider colision = obj.GetComponent<Collider>();
                    if (colision != null ) {
                        if (i== count )
                        {
                            colision.enabled = true;
                        }
                        else 
                        {
                            colision.enabled = false;
                        }
                        
                    }
                    
                }
            }
        }

        


    }
}
