using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CircleBin : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private float speed = 500;
    [SerializeField] private Rigidbody2D rb;
    // Update is called once per frame
    public void OnInit(Vector3 dir)
    {
        Debug.Log(dir);
        rb.velocity = dir * speed * Time.deltaTime;
        Invoke(nameof(OnDespawn), 3f);
    }

    public void OnDespawn()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<Enemy>().OnDespawn();
            GameManager.instance.SetScore(1);
            GameManager.instance.SetScoreText();
        }
    }
}
