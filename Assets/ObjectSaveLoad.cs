using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSaveLoad : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        // 1번키 누르면 랜덤한 모양, 크기, 위치, 회전이 된 오브젝트 만들자
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // 모양을 랜덤하게 뽑자 (0 ~ 3)
            int type = Random.Range(0, 4);

            // type 모양으로 GameObject 만들자
            GameObject go = GameObject.CreatePrimitive((PrimitiveType)type);

            // 크기, 위치, 회전 랜덤하게 하자.
            go.transform.localScale = Vector3.one * Random.Range(0.5f, 2.0f);
            go.transform.position = Random.insideUnitSphere * Random.Range(1.0f, 20.0f);
            go.transform.rotation = Random.rotation;
        }
    }
}
