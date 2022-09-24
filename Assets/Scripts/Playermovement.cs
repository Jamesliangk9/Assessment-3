using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private Transform[] wayPoints;
    [SerializeField] public int order;


    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[order].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, wayPoints[order].position) <= 0.05f)
        {
            order++;
            if (order > wayPoints.Length - 1) {
                order = 0;
            }
        }
        Vector2 direction = wayPoints[order].position - transform.position;
        GetComponent<Animator>().SetFloat("DirectionX", direction.x);
        GetComponent<Animator>().SetFloat("DirectionY", direction.y);
    }
}
