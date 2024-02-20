using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinPool : MonoBehaviour
{
    private static BinPool _instance = null;
    public static BinPool instance => _instance;

    [SerializeField] private GameObject CircleBinPrefab;
    [SerializeField] private List<GameObject> listBin = new List<GameObject>();
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            return;
        }
        if (_instance.gameObject.GetInstanceID() != this.gameObject.GetInstanceID()) { }
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetBin()
    {
        foreach(GameObject tmp in listBin)
        {
            if(tmp.activeSelf)
            {
                continue;
            }
            return tmp;
        }
        GameObject g = Instantiate(CircleBinPrefab, this.transform.position, Quaternion.identity);
        listBin.Add(g);
        g.SetActive(false);
        return g;
    } 
}
