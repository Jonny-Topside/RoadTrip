using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

  public  LaneScript lane1;
  public  LaneScript lane2;
  public  LaneScript lane3;



    // Use this for initialization
    void Start () {
        transform.position = new Vector3( lane2.transform.position.x, transform.position.y, transform.position.z);
     
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-0.5f, 0, 0));
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(transform.position.x == lane2.transform.position.x)
            {
                transform.position = new Vector3(lane1.transform.position.x, transform.position.y, transform.position.z);
            }
            else if (transform.position.x == lane3.transform.position.x)
            {
                transform.position = new Vector3(lane2.transform.position.x, transform.position.y, transform.position.z);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (transform.position.x == lane2.transform.position.x)
            {
                transform.position = new Vector3(lane3.transform.position.x, transform.position.y, transform.position.z);
            }
            else if (transform.position.x == lane1.transform.position.x)
            {
                transform.position = new Vector3(lane2.transform.position.x, transform.position.y, transform.position.z);
            }
        }
    }
}
