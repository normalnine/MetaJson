using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
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

[System.Serializable]
public struct FriendInfo
{
    public List<UserInfo> data;
}

public class JsonStudy : MonoBehaviour
{
    // 나의 정보
    public UserInfo myInfo;

    // 유저 정보를 여러개 들고 있는 변수
    public List<UserInfo> friendList = new List<UserInfo>();

    // friendList의 key값을 만드어 주기 위한 구조체
    FriendInfo info = new FriendInfo();

    void Start()
    {
        for(int i=0; i<10; i++)
        {
            myInfo = new UserInfo();

            myInfo.userName = "강동현" + i;
            myInfo.age = 100;
            myInfo.height = 300;
            myInfo.gender = false;
            myInfo.favoriteFood = new List<string>();
            myInfo.favoriteFood.Add("김밥");
            myInfo.favoriteFood.Add("피자");
            myInfo.favoriteFood.Add("고기");

            friendList.Add(myInfo);
        }

        info.data = friendList;

        string s = JsonUtility.ToJson(info, true);
        print(s);
        
        //{
        //    "jsonData" :    {
        //                        "user_name" : "강동현",
        //                        "age" : 100,
        //                        "height" : 300,
        //                        "gender" : false,
        //                        "favoritFood" : ["김밥", "피자", "고기"]
        //                    }
        //}


    }

    void Update()
    {
        // 1번키 누르면
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            // myInfo를 Json 형태로 만들자
            string jsonData = JsonUtility.ToJson(info, true);
            print(jsonData);
            // jsonData를 파일로 저장
            FileStream file = new FileStream(Application.dataPath + "/myinfo.txt", FileMode.Create);

            // json string 데이터를 byte 배열로 만든다
            byte[] byteData = Encoding.UTF8.GetBytes(jsonData);
            // byteData를 file에 쓰자
            file.Write(byteData, 0, byteData.Length);

            file.Close();
        }

        // 2번키 누르면
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            // myInfo.txt를 읽어오자
            FileStream file = new FileStream(Application.dataPath + "/myinfo.txt", FileMode.Open);
            // file의 크기만큼 byte 배열을 할당한다
            byte[] byteData = new byte[file.Length];
            // byteData에 file의 내용을 읽어온다.
            file.Read(byteData, 0, byteData.Length);
            // 파일을 닫아주자
            file.Close();

            // byteData를 문자열로 바꾸자
            string jsonData = Encoding.UTF8.GetString(byteData);
            // 문자열로 되어있는 jsonData를 myInfo에 parsing한다.
            myInfo = JsonUtility.FromJson<UserInfo>(jsonData);
        }
    }
}
