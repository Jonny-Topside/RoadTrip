using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private LaneScript lane1;
    private LaneScript lane2;
    private LaneScript lane3;
    public LaneScript[] lanes;

    private LaneScript myLane;
    public HeartScript[] hearts;
    public int lives = 3;
    Vector3 check1Pos = Vector3.zero;
    Vector3 check2Pos = Vector3.zero;
    Vector3 startPoint = Vector3.zero;
    CheckPoint[] checkpoints;

    bool DescentRange(float a, float b)
    {
        if (Mathf.Abs(b - a) > 0.5f)
            return false;
        else
            return true;
    }
    void AssaignLanes()
    {

     
        LaneScript temp;
        bool swapped = false;
        lane1 = lanes[0];
        lane2 = lanes[1];
        lane3 = lanes[2];
        while (true)
        {
            swapped = false;
            for (int i = 0; i < lanes.Length; i++)
            {
                if (i < 2)
                {
                    if (lanes[i].transform.position.z > lanes[i + 1].transform.position.z)
                    {
                        temp = lanes[i];
                        lanes[i] = lanes[i + 1];
                        lanes[i + 1] = temp;
                        swapped = true;
                    }

                }
            }
            if (swapped == false)
            {
                break;
            }
        }

        lane1 = lanes[0];
        lane2 = lanes[1];
        lane3 = lanes[2];
    }
    float speed = 0.2f;

    float startY;
    bool crashing = false;
    float crashtime = 0.0f;
    void OrganizeHearts()
    {

        HeartScript temp;
        bool swapped = false;

        while (true)
        {
            swapped = false;
            for (int i = 0; i < lanes.Length; i++)
            {
                if (i < 2)
                {
                    if (hearts[i].transform.localPosition.x > hearts[i + 1].transform.localPosition.x)
                    {
                        temp = hearts[i];
                        hearts[i] = hearts[i + 1];
                        hearts[i + 1] = temp;
                        swapped = true;
                    }

                }
            }
            if (swapped == false)
            {
                break;
            }
        }

    }
    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<createCanvasScript>();
        lanes = GameObject.FindObjectsOfType<LaneScript>();
        hearts = GameObject.FindObjectsOfType<HeartScript>();
        AssaignLanes();
        OrganizeHearts();
        transform.position = startPoint = check1Pos = check2Pos = new Vector3(9, 0.9f, lane2.transform.position.z);
        startY = 0.9f;
        myLane = lane2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed * Time.timeScale, 0, 0));
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (DescentRange(transform.position.z, lane2.transform.position.z))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, lane1.transform.position.z);
                myLane = lane1;
            }
            else if (DescentRange(transform.position.z, lane3.transform.position.z))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, lane2.transform.position.z);
                myLane = lane2;
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (DescentRange(transform.position.z, lane2.transform.position.z))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, lane3.transform.position.z);
                myLane = lane3;
            }
            else if (DescentRange(transform.position.z, lane1.transform.position.z))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, lane2.transform.position.z);
                myLane = lane2;
            }
        }
     if (!DescentRange(transform.position.z,myLane.transform.position.z) || !DescentRange(transform.position.x, myLane.transform.position.x))
     {
         crashing = true;
     }
        if (crashing)
        {
            crashtime += 0.5f;
            if (crashtime > 5.0f)
            {
                transform.rotation = new Quaternion(0, 0, 0, 1);
                transform.Rotate(0, -180, 0);
                transform.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
                transform.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0);
                transform.position = new Vector3(transform.position.x, startY, myLane.transform.position.z);
                crashtime = 0.0f;
                crashing = false;
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<ObstacleScript>())
        {
            crashing = true;

            for (int i = 0; i < hearts.Length; i++)
            {
                if (hearts[i].GetComponent<SpriteRenderer>().color.a == 1)
                {
                    transform.GetComponent<Rigidbody>().velocity = new Vector3(0, Random.Range(0, 50), Random.Range(-100, 100));
                    hearts[i].GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0.5f);
                    lives--;
                    return;
                }
            }
            other.transform.GetComponent<Collider>().enabled = false;
        }

        if(other.transform.GetComponent<CheckPoint>())
        {
           if(check1Pos == startPoint )
            {
                check1Pos = other.transform.position;
            }
           else if (check2Pos == startPoint)
            {
                check2Pos = other.transform.position;
            }
        }
    }

    public void ContuneFromCheckpoint()
    {
        if(check2Pos != startPoint)
        {
            transform.position = check2Pos;
        }
        else if (check1Pos != startPoint)
        {
            transform.position = check1Pos;
        }
        else
        {
            transform.position = startPoint;
        }
    }

}
