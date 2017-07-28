using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeat : MonoBehaviour
{
    LineRenderer myLineRenderer;
    PlayerController thePlayer;
    Vector3 tempLast;
    Vector3 yo;
    float heartspeed = 0.25f;
    // Use this for initialization

    void Start()
    {
        if (thePlayer == null)
        {
            thePlayer = GameObject.FindObjectOfType<PlayerController>();
        }
      if (GetComponent<LineRenderer>())
        {
            myLineRenderer = GetComponent<LineRenderer>();
        }
       
    }

    // Update is called once per frame
    void Update()
    {

        tempLast = myLineRenderer.GetPosition(myLineRenderer.numPositions - 1);
        yo = myLineRenderer.GetPosition(0);
        for (int i = 0; i < myLineRenderer.numPositions; i++)
        {
          
            Vector3 temp = myLineRenderer.GetPosition(i);

            Vector3 tempNext;
            if (i < myLineRenderer.numPositions-1)
            {

                tempNext = myLineRenderer.GetPosition(i + 1);
                temp = new Vector3(tempNext.x + heartspeed <= 23 ? tempNext.x + heartspeed : 0, tempNext.y, tempNext.z);
                myLineRenderer.SetPosition(i, temp);

            }
            else
            {
                temp = myLineRenderer.GetPosition(0);
                temp = new Vector3(temp.x + heartspeed <= 23 ? temp.x + heartspeed : 0, temp.y, temp.z);
                myLineRenderer.SetPosition( i,temp);
           
            }

        }
    }
}
