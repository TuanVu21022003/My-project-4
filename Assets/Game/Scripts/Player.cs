using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private CircleBin CircleBinPrefab;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speedMove = 500, speedRotation = 300;
    [SerializeField] private Transform ShootPoint;
    [SerializeField] private HealthBar healthBar;
    private Vector3 dir;
    private float angle = 0;
    private float hp;
    void Start()
    {
        hp = 100;
        healthBar.OnInit(hp, transform);
    }

    // Update is called once per frame
    void Update()
    {
        dir = transform.right;
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Da nhan" + this.transform.right);
            Instantiate(CircleBinPrefab, ShootPoint.position, Quaternion.identity).OnInit(this.transform.right);
        }

        MoveController();
        RotationController();
    }

    public void MoveController()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = dir * speedMove * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            rb.velocity = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = dir * -1 * speedMove * Time.deltaTime;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            rb.velocity = Vector2.zero;
        }
    }

    public void RotationController()
    {
        if (Input.GetKey(KeyCode.A))
        {
            angle += speedRotation * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        if (Input.GetKey(KeyCode.D))
        {
            angle -= speedRotation * Time.deltaTime;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }

    public void OnHit(float damage)
    {
        this.hp -= damage;
        if(this.hp <= 0)
        {
            Destroy(this.gameObject);
        }
        healthBar.SetHP(hp);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            OnHit(10);
        }
    }
}
