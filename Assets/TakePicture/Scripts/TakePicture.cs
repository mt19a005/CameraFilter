using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class TakePicture : MonoBehaviour
{
    //撮影ボタン
    Button takePicButton;
    Display display;
    void Start()
    {
        takePicButton = GameObject.FindGameObjectWithTag("TakePicture").GetComponent<Button>();
        takePicButton.onClick.AddListener(TakeOnClick);
        display = GetComponent<Display>();
    }
    //撮影処理
    //撮影
    //Model.TookPictureに画像を贈る
    //画面遷移
    void TakeOnClick()
    {
        Debug.Log("You have clicked the button!");
        display.Take();
        SceneManager.LoadScene("ProcessScene");
    }

}