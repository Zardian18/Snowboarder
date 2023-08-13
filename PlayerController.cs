using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float torqueAmount = 1f;
    private SurfaceEffector2D surfaceEffector;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float boostedSpeed = 0.1f;
    [SerializeField]
    private float orignalSpeed = 20f;
    public bool canMove = true;
    [SerializeField]
    private float maxSpeedLimit = 35f, minSpeedLimit = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector = GameObject.FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Movement();
            SpeedUp();
            SpeedDown();
        }
    }

    void Movement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void SpeedUp()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (surfaceEffector.speed <= maxSpeedLimit)
            {
                surfaceEffector.speed += boostedSpeed;
            }
            else
            {
                surfaceEffector.speed = maxSpeedLimit;
            }
            
        }
        else if (!(Input.GetKeyUp(KeyCode.W)) && surfaceEffector.speed>orignalSpeed)
        {
            surfaceEffector.speed -=boostedSpeed;
        }

        
    }
    void SpeedDown()
    {
        if (Input.GetKey(KeyCode.S))
        {
            if (surfaceEffector.speed > minSpeedLimit)
            {
                surfaceEffector.speed -= boostedSpeed / 3;
            }
            else
            {
                surfaceEffector.speed = minSpeedLimit;
            }
        }
        else if(surfaceEffector.speed<orignalSpeed)
        {
            surfaceEffector.speed += boostedSpeed/3;
        }
    }
}
