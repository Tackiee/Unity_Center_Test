using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCenterPos : MonoBehaviour
{
    public GameObject Player;
    public GameObject Base;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(GetDist());
        if (GetDist() < 10)
            Debug.Log("近い距離です");
        else if (GetDist() > 10 && GetDist() < 20)
            Debug.Log("少し離れています");
        else
            Debug.Log("遠いです");
    }

    float GetDist()
    {
        Vector3 Tr_Pl;
        Vector3 Tr_Ba;
        float dist;
        Tr_Pl = Player.gameObject.transform.position;
        Tr_Ba = Base.gameObject.transform.position;
        dist = Mathf.Sqrt(Mathf.Pow(Tr_Pl.x - Tr_Ba.x, 2) + Mathf.Pow(Tr_Pl.z - Tr_Ba.z, 2));

        return dist;
    }
}
