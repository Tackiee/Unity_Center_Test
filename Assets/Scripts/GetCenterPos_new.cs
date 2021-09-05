using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCenterPos_new : MonoBehaviour
{
    public GameObject Player;
    public GameObject Base;
    public Text showDist;
    public HoldAndFall HFScript;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetDist());
        showDist.text = GetDist().ToString() + "m";
        if (HFScript.attacheGrand) //地面に接地したら判定
        {
            if (GetDist() < 1.5)
                Debug.Log("近い距離です");
            else if (GetDist() >= 1.5 && GetDist() < 2)
                Debug.Log("少し離れています");
            else
                Debug.Log("遠いです");
        }
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
