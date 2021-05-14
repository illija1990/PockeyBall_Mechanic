using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Ball ball;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        Vector3 tergetPosition = new Vector3(transform.position.x, ball.transform.position.y+5, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, tergetPosition, _speed * Time.fixedDeltaTime);
    }
}
