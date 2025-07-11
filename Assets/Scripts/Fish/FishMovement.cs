using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class FishMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private GameManager gameManager;
    private GameObject player;

    private Vector2 direction;
    private Vector2 destination;
    // Start is called before the first frame update
    void Start()
    {
        CheckWanderDirection();
        gameManager = GameObject.FindObjectOfType<GameManager>();
        player = gameManager.player;
    }

    // Update is called once per frame
    void Update()
    {
        float speedToUse = CheckForPlayer();
        Wander(speedToUse);
    }

    void CheckWanderDirection()
    {
        direction = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        float mag = Random.Range(1, 10);
        FlipFish();
        
        // int layermask = ~(1 << LayerMask.NameToLayer("Fish"));
        // RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, mag);
        // Debug.DrawRay(transform.position, direction * mag, Color.red, 1f);  
        // if (hit.collider.gameObject.CompareTag("Wall"))
        // {
        //     destination = hit.point - direction*2;
        //     return;
        // }
        destination = transform.position + new Vector3(direction.x, direction.y, 0) * mag;
    }

    void Wander(float speed)
    {
        if (Vector2.Distance(transform.position, destination) > 0.5f)
        {
            transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
        }
        else
        {
            CheckWanderDirection();
        }
    }

    float CheckForPlayer()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 3.5)
        {
            direction = (transform.position - player.transform.position).normalized;
            destination = transform.position + new Vector3(direction.x, direction.y, 0) * 5;
            if (direction.x < 0f)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
            return speed;
        }
        return walkSpeed;
    }

    public void SetSpeed(float value)
    {
        walkSpeed = value;
        speed += walkSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            direction *= -1;
            destination *= direction;
            FlipFish();
        }
    }

    void FlipFish()
    {
        if (direction.x < 0f)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
    }
}
