using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickFuwa : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject friendCountText;
    public int friendCount = 0;
    private RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //マウスがクリックされたら
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition); //マウスのポジションを取得してRayに代入

            if (Physics.Raycast(ray, out hit))  //マウスのポジションからRayを投げて何かに当たったらhitに入れる
            {
                if ( hit.collider.gameObject.tag == "KeukeGen")
                {
                    if (hit.collider.gameObject.GetComponent<FuwaChan>() != null)
                    {
                        hit.collider.gameObject.GetComponent<FuwaChan>().showParticle();
                        if (hit.collider.gameObject.GetComponent<FuwaChan>().clickCount == 5)
                        {
                            friendCount++;
                            friendCountText.GetComponent<Text>().text = friendCount.ToString();
                        }
                    }
                }
                //string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
                //Debug.Log(objectName); //オブジェクト名をコンソールに表示
            }
        }
    }
}
