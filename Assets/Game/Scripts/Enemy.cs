using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private float speed = 300;
    [SerializeField] private Rigidbody2D rb;


    
    // Start is called before the first frame update
    void Start()
    {
        Target = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        OnInit();
    }

    public void OnInit()
    {
        Vector2 dir = (Target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        rb.velocity = dir * speed * Time.deltaTime;
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }


}
