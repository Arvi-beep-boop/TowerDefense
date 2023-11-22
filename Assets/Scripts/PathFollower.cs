using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float speed;
    private List<Transform> wayPoints;
    private int currentPoint;

    private void Awake()
    {
        currentPoint = 0;
        GameObject parent = GameObject.Find("Path");
        parent.GetComponentsInChildren<Transform>(false, wayPoints);
        wayPoints.RemoveAt(0); // skip parent's transform
    }
   
    void Update()
    {
        if (currentPoint >= wayPoints.Count) 
        {
            Debug.Log("Final wayPoint has been reached! TODO: ?");
            return;
        }
        Move();
        if(isTargetReached()) { currentPoint++; };
    }

    bool isTargetReached()
    {
        if((gameObject.transform.position - wayPoints[currentPoint].position).magnitude <= offset) 
        {
            return true;
        }
        return false;
    }
    private void Move()
    {
        Vector3 direction = (wayPoints[currentPoint].position - gameObject.transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
