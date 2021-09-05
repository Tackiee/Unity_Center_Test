using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldAndFall : MonoBehaviour
{
    private Vector3 target;
    Vector3 mousePos;
    private bool beRay = false;
    bool clickJudge = false;
    public bool attacheGrand = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //クリック中はRayが作動
        {
            RayCheck();
        }

        if (beRay)
        {
            MovePosition();
        }

        if (Input.GetMouseButtonUp(0))  //クリックが離れたらRayの作動を切る
        {
            beRay = false;
        }
        
        if(clickJudge) //ボタンが押されたらuseGravityをオンにしてオブジェクトを落とす
        {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    private void RayCheck() //オブジェクトに当たっているかを検知．「落ちる」ボタンクリックによる瞬間移動を防ぐ
    {
        Ray ray = new Ray();
        RaycastHit hit = new RaycastHit();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, Mathf.Infinity) && hit.collider == this.gameObject.GetComponent<Collider>())
        {
            beRay = true;
        }
        else
        {
            beRay = false;
        }

    }

    private void MovePosition()
    {
        if(Input.GetMouseButton(0))
        {
            mousePos = Input.mousePosition;
            mousePos.z = 5.0f; //mousePos.zの値はオブジェクトのy座標と一致させる必要あり

            target = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, mousePos.z));
            this.transform.position = target;
        }
    }

    public void FallButton() //落ちるボタンを押したかどうかを判定
    {
        clickJudge = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Base")
            attacheGrand = true;

    }
}
