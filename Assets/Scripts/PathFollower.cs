using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float speed;
    private List<Transform> wayPoints = new List<Transform> { };
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
        return (gameObject.transform.position - wayPoints[currentPoint].position).magnitude <= offset;
    }

    private void Move()
    {
        Vector3 direction = (wayPoints[currentPoint].position - gameObject.transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
