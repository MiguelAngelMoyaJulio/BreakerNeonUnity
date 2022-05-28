using System;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    // private Rigidbody2D rb;
    // private Vector2 direction;
    [SerializeField] float speed = 20f;
    private float Xmin;
    private float Xmax;
    private float maxBounceAngle = 75f;

    // void Awake()
    // {
    //     rb = GetComponent<Rigidbody2D>();
    // }

    // Start is called before the first frame update
    void Start()
    {
        SetBoudaries();
    }
    private void Update()
    {
        MovePaddle();
    }

    private void MovePaddle()
    {
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float NewPosX = Mathf.Clamp(transform.position.x + deltaX, Xmin, Xmax);
        transform.position = new Vector2(NewPosX, transform.position.y);
    }
    private void SetBoudaries()
    {
        Camera game = Camera.main;
        Xmin = game.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        Xmax=game.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;

    }
    // Update is called once per frame
    // void Update()
    // {
    //     if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
    //     {
    //         this.direction = Vector2.right;
    //     }
    //     else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
    //     {
    //         this.direction = Vector2.left;
    //     }
    //     else
    //     {
    //         this.direction = Vector2.zero;
    //     }
    // }
    // void FixedUpdate()
    // {
    //     if (this.direction != Vector2.zero)
    //     {
    //         rb.AddForce(this.direction * this.speed);
    //     }
    // }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Ball ball = col.gameObject.GetComponent<Ball>();
        if (ball != null)
        {
            Vector3 paddlePosition = transform.position;
            // grab the position of the first contact with the ball
            Vector2 contactPoint = col.GetContact(0).point;
            float offset = paddlePosition.x - contactPoint.x;
            // contact with other objects
            float width = col.otherCollider.bounds.size.x / 2;
            // current angle
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            // bounce angle
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            // set the new value but cant be greater than maxBounceAngle 
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity =
                rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }
    }
}