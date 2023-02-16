using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 _targetVector;

    private void Update()
    {
        _targetVector = transform.position - transform.right;
        transform.position = Vector2.MoveTowards(transform.position, _targetVector, 0.007f);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Chest chest))
        {
            transform.Rotate(0, 180, 0);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<AlarmZone>(out AlarmZone alarm))
        {
            alarm.Begin();
        }
    }
}
