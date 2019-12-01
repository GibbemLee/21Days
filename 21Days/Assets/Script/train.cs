using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class train : MonoBehaviour
{
    public enum MoveType
    {
        WAY_POINT,
        LOOK_AT
    }
    
    public MoveType moveType = MoveType.WAY_POINT;
    public float trainSpeed;
    public float damping = 3.0f;
    public string nextScene = "Home";
    public Text text;

    //public Vector3 dir = new Vector3(0, 0, 1);

    private Transform tr;
    private Transform[] points;
    private int nextIdx = 1;

    void Start()
    {
        tr = GetComponent<Transform>();
        points = GameObject.Find("WayPoints").GetComponentsInChildren<Transform>();
        Debug.Log(points[1].position);
    }
    
    void Update()
    {
        //transform.position = transform.position + dir * trainSpeed * Time.deltaTime;

        switch (moveType)
        {
            case MoveType.WAY_POINT:
                MoveWayPoint();
                break;
        }
    }

    void MoveWayPoint()
    {
        Vector3 direction = points[nextIdx].position - tr.position;
        Quaternion rot = Quaternion.LookRotation(direction);
        tr.rotation = Quaternion.Slerp(tr.rotation, rot, Time.deltaTime * damping);

        tr.Translate(Vector3.forward * Time.deltaTime * trainSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("wayPoint"))
        {
            //Debug.Log(nextIdx);
            nextIdx = (++nextIdx >= points.Length) ? 0 : nextIdx;
            /*if (nextIdx == 0)
            {
                SceneManager.LoadScene(nextScene);
            }
            if (nextIdx == 3)
            {
                text.text = "Stage1";
            }
            if (nextIdx == 13)
            {
                text.text = "Stage2";
            }
            if (nextIdx == 18)
            {
                text.text = "Stage3";
            }
            if (nextIdx == 23)
            {
                text.text = "Stage4";
            }
            if (nextIdx == 25)
            {
                text.text = "Go to Home";
            }*/
        }
    }
}
