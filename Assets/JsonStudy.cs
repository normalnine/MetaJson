using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct UserInfo
{
    // 이름
    public string userName;
    // 나이
    public int age;
    // 키
    public float height;
    // 성별 (true : 여성, false : 남성)
    public bool gender;
    // 좋아하는 음식
    public List<string> favoriteFood;
}

public class JsonStudy : MonoBehaviour
{
    // 나의 정보
    public UserInfo myInfo;

    void Start()
    {
        myInfo = new UserInfo();

        myInfo.userName = "강동현";
        myInfo.age = 100;
        myInfo.height = 300;
        myInfo.gender = false;
        myInfo.favoriteFood = new List<string>();
        myInfo.favoriteFood.Add("김밥");
        myInfo.favoriteFood.Add("피자");
        myInfo.favoriteFood.Add("고기");

        //{
        //    "user_name" : "강동현",
        //    "age" : 100,
        //    "height" : 300,
        //    "gender" : false,
        //    "favoritFood" : ["김밥", "피자", "고기"]
        //}

        // myInfo를 Json 형태로 만들자.
        string jsonData = JsonUtility.ToJson(myInfo, true);
        print(jsonData);
    }

    void Update()
    {
        
    }
}
