using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image downloadImage;

    void Start()
    {
    
    }

    void Update()
    {
        
    }

    public void OnClickGet()
    {
        // todos
        HttpInfo info = new HttpInfo();
        info.Set(RequestType.GET, "/todos", OnReceiveGet);

        // info의 정보로 요청을 보내자
        HttpManager.Get().SendRequest(info);
    }

    void OnReceiveGet(DownloadHandler downloadHandler)
    {
        print("OnReceiveGet : " + downloadHandler.text);
    }

    public void OnClickComment()
    {
        HttpInfo info = new HttpInfo();
        info.Set(RequestType.GET, "/comments", (DownloadHandler downloadHandler) => {
            print("코멘트 리스트 : " + downloadHandler.text);
        });

        // 요청
        HttpManager.Get().SendRequest(info);
    }

    public void PostTest()
    {
        HttpInfo info = new HttpInfo();
        info.Set(RequestType.POST, "/sing_up", (DownloadHandler downloadHandler) => {
            // Post 데이터 전송했을 때 서버로부터 응답 옵니다~
        });

        SignUpInfo signUpInfo = new SignUpInfo();
        signUpInfo.userName = "강동현";
        signUpInfo.age = 30;
        signUpInfo.birthday = "940709";

        info.body = JsonUtility.ToJson(signUpInfo);

        HttpManager.Get().SendRequest(info);
    }

    public void OnClickDownloadImage()
    {
        HttpInfo info = new HttpInfo();
        info.Set(RequestType.TEXTURE, "https://placehold.co/400x400.png?text=Beach", OnCompleteDownloadTexture, false);

        HttpManager.Get().SendRequest(info);
    }

    void OnCompleteDownloadTexture(DownloadHandler downloadHandler)
    {
        // 다운로드된 Image 데이터를 Sprite로 만든다
        // Texture2D --> Sprite
        Texture2D texture = ((DownloadHandlerTexture)downloadHandler).texture;
        downloadImage.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
    }
}
