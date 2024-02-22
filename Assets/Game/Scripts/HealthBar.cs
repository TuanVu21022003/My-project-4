using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image imageFill;

    private float maxHp, hp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        imageFill.fillAmount = Mathf.Lerp(imageFill.fillAmount, hp/maxHp, Time.deltaTime * 4f);
    }

    public void OnInit(float maxHp)
    {
        this.maxHp = maxHp;
        this.hp = maxHp;
    }

    public void SetHP(float hp)
    {
        this.hp = hp;
    }
}
