using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imageFill;
    [SerializeField] private Vector3 offset;

    private float maxHp, hp;
    private Transform Target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp/maxHp, Time.deltaTime * 4f);
        transform.position = Target.position + offset;
    }

    public void OnInit(float maxHp, Transform target)
    {
        this.maxHp = maxHp;
        this.hp = maxHp;
        imageFill.fillAmount = 1;
        this.Target = target;
    }

    public void SetHP(float hp)
    {
        this.hp = hp;
    }
}
