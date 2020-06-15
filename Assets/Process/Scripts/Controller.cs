using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    //Make sure to attach these Buttons in the Inspector
    Button[] changeButtonComp;
    static GameObject display;
    GameObject content;
    GameObject processButtonObj;
    GameObject backButtonObj;


    void Start()
    {
        //加工ボタン配置位置
        content = GameObject.FindGameObjectWithTag("Content");
        
        processButtonObj = (GameObject)Resources.Load("Prefab/Button/Button");
        backButtonObj = GameObject.FindGameObjectWithTag("BackButton");

        //加工ボタン
        for (int i = 0; i < Enum.GetNames(typeof(ProcessType)).Length - 1; i++)
        {
            GameObject instanedButton = (GameObject)Instantiate(processButtonObj);
            instanedButton.transform.SetParent(content.transform, false);
            InitButton(i, instanedButton);
        }
        

        //バック
        backButtonObj.GetComponent<Button>().onClick.AddListener(BackOnClick);

    }

    //加工ボタン追加
    void InitButton(int num, GameObject instanedButton)
    {
        instanedButton.GetComponent<Button>().onClick.AddListener(() => ProcessOnClick((ProcessType)num));
        instanedButton.GetComponentInChildren<Text>().text = ((ProcessType)num).ToString();
    }

    //加工ボタン処理
    void ProcessOnClick(ProcessType info)
    {
        Model.ChangeType(info);
    }

    //バックボタン処理
    void BackOnClick()
    {
        SceneManager.LoadScene("TakePicScene");
    }
}