using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 targetVector;

    void Update()
    {
        targetVector = transform.position - transform.right;
        transform.position = Vector2.MoveTowards(transform.position, targetVector, 0.007f);
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Chest chest))
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
