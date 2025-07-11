using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceToTarget() > 0.2f)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        Vector3 dir = (target.transform.position - transform.position);
        
        transform.position += new Vector3(dir.x * (Time.deltaTime * 1), dir.y * (Time.deltaTime * 1), 0);
    }

    private float DistanceToTarget()
    {
        return Vector2.Distance(transform.position, target.transform.position);
    }
}
