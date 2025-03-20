using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UserInfo
{
    // �̸�
    public string userName;
    // ����
    public int age;
    // Ű
    public float height;
    // ���� (true : ����, false : ����)
    public bool gender;
    // �����ϴ� ����
    public List<string> favoriteFood;
}

public class JsonStudy : MonoBehaviour
{
    // ���� ����
    public UserInfo myInfo;

    void Start()
    {
        myInfo = new UserInfo();

        myInfo.userName = "������";
        myInfo.age = 100;
        myInfo.height = 300;
        myInfo.gender = false;
        myInfo.favoriteFood = new List<string>();
        myInfo.favoriteFood.Add("���");
        myInfo.favoriteFood.Add("����");
        myInfo.favoriteFood.Add("���");

        //{
        //    "user_name" : "������",
        //    "age" : 100,
        //    "height" : 300,
        //    "gender" : false,
        //    "favoritFood" : ["���", "����", "���"]
        //}

        // myInfo�� Json ���·� ������.
        string jsonData = JsonUtility.ToJson(myInfo, true);
        print(jsonData);
    }

    void Update()
    {
        
    }
}
