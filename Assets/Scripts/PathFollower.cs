using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private float offset;
    [SerializeField] private float speed;
    private List<Transform> waypoints = new List<Transform> { };
    private int currentPoint;

    private void Awake()
    {
        currentPoint = 0;
        GameObject parent = GameObject.Find("Path");
        parent.GetComponentsInChildren<Transform>(false, waypoints);
        waypoints.RemoveAt(0); // skip parent's transform
    }
   
    void Update()
    {
        if (currentPoint >= waypoints.Count) 
        {
            Debug.Log("Final wayPoint has been reached! TODO: ?");
            if (this.gameObject.TryGetComponent<Enemy>(out Enemy enemy))
                LevelManager.instance.RemoveHealth(enemy.damage);
            Destroy(this.gameObject);
            return;
        }
        Move();
        if(isTargetReached()) { currentPoint++; };
    }

    bool isTargetReached()
    {
        return (gameObject.transform.position - waypoints[currentPoint].position).magnitude <= offset;
    }

    private void Move()
    {
        Vector3 direction = (waypoints[currentPoint].position - gameObject.transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
