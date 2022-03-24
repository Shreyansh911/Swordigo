using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform PointA, PointB;
    [SerializeField] private float _speed = 1;

    private bool _switching = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_switching == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointB.position, _speed * Time.deltaTime);
        }

        else if (_switching == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, PointA.position, _speed * Time.deltaTime);
        }


        if (transform.position == PointA.position)
        {
            _switching = true;
        }
        else if (transform.position == PointB.position)
        {
            _switching = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
