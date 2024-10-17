using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : MonoBehaviour
{

    private Vector2 movement;
    private Rigidbody2D _rigidbody;

    public Transform player;
    public Transform enemy;
    public float fleeRange;
    public float fleeSpeed;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, enemy.position);

        if (distanceToPlayer < fleeRange)
        {

            Vector2 desiredVelocity = enemy.position - player.position;
            desiredVelocity.Normalize();
            movement = desiredVelocity;

            if (distanceToPlayer > fleeRange)
            {
                movement = Vector2.zero;
            }

        }

        else
        {
            movement = Vector2.zero;
        }

        _rigidbody.MovePosition((Vector2)enemy.position + (movement * fleeSpeed * Time.fixedDeltaTime));
    }

}