using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour
{

    private Vector2 movement;
    private Rigidbody2D _rigidbody;

    public Transform player;
    public Transform enemy;
    public float seekRange;
    public float seekSpeed;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, enemy.position);
       

        if (distanceToPlayer < seekRange)
        {
            Vector2 desierdVelocity = player.position - enemy.position;
            desierdVelocity.Normalize();
            movement = desierdVelocity;

            if (distanceToPlayer > seekRange)
            {
                float slowDown = seekSpeed / 2;
                movement.x = slowDown;
                
            }
        }

        _rigidbody.MovePosition((Vector2)enemy.position + (movement * seekSpeed * Time.fixedDeltaTime));

    }
}
