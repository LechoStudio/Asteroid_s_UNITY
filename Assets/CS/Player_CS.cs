
using UnityEngine;

public class Player_CS : MonoBehaviour
{
    public float thrustSpeed = 1.0f;
    public float turnSpeed = 1.0f;
    private Rigidbody2D _rigidbody;
    private bool _trusting;
    private float _turnDirection;
    public Bullet_CS bulletObj;
    private GameManager gameManager;
    private void Awake()
    {

        _rigidbody = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {

        _trusting = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _turnDirection = 1.0f;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _turnDirection = -1.0f;
        }
        else
        {
            _turnDirection = 0.0f;
        }
        if (Input.GetKeyDown(KeyCode.F) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

    }
    private void FixedUpdate()
    {
        if (_trusting)
        {
            _rigidbody.AddForce(this.transform.up * thrustSpeed);
        }
        if (_turnDirection != 0.0f)
        {
            _rigidbody.AddTorque(_turnDirection * this.turnSpeed);
        }
    }
    private void Shoot()
    {
        Bullet_CS bullet = Instantiate(this.bulletObj, this.transform.position + this.transform.up * 0.2f, this.transform.rotation);
        bullet.Project(this.transform.up);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;
            this.gameObject.SetActive(false);
            
            gameManager.PlayerDied();
           
            //  gameObject.SetActive(false);
        }

    }
    public void Restart()
    {
        Vector3 pos = GameObject.FindObjectOfType<Camera>().transform.localPosition;
        //this.gameObject.SetActive(true);
        //this.transform.= pos;
        // = GameObject.FindObjectOfType<Camera>().transform;
    }
}
