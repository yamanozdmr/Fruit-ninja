using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    public float minVelo = 0.1f;


    public Rigidbody2D rb;
    private Vector3 lastMousePous;
    private Vector3 MouseVelo;
    private Collider2D collider;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
    }

    
    void FixedUpdate()
    {
        collider.enabled = IsMouseMoving();
        SetBladeToMouse();
    }

    private void SetBladeToMouse()
    {
      var mousePos = Input.mousePosition;
        mousePos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousePos);
    }


    private bool IsMouseMoving()
    {
        Vector3 curMousePos = transform.position;
        float traveled = (lastMousePous - curMousePos).magnitude;

        lastMousePous = curMousePos;
        if (traveled > minVelo)
        {
            return true;
        }
        else
        {
            return false;
        }


    }






}
