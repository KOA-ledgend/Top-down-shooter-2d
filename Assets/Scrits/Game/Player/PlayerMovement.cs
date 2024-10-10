using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float movementSpeed = 7f;

    public Rigidbody2D _rigidbody;
    public Camera _camera;

    Vector2 movement;
    Vector2 mousePosition;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

       mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + movement * movementSpeed * Time.fixedDeltaTime);
        Vector2 lookDirection = mousePosition - _rigidbody.position;

        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
        _rigidbody.rotation = angle;
    }
}
