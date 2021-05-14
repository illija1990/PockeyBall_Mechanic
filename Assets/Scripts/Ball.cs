using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _forceSpeed;
    private Rigidbody _playerBody;

    private void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _playerBody.isKinematic = false;
            _playerBody.AddForce(Vector3.up * _forceSpeed, ForceMode.Impulse);
        }

        if(Input.GetMouseButtonUp(0))
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            if(Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.collider.TryGetComponent(out Segment block))
                {
                    _playerBody.isKinematic = true;
                    _playerBody.velocity = Vector3.zero;
                }
            }
        }
    }
}
