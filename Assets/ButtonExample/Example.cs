//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;

//public class Example : MonoBehaviour
//{
//    //Make sure to attach these Buttons in the Inspector
//    GameObject[] changeButton;
//    Button[] changeButtonComp;
//    GameObject text;
//    void Start()
//    {
//        changeButton = GameObject.FindGameObjectsWithTag("ChangeButton");
//        text = GameObject.FindGameObjectWithTag("Respawn");

//        changeButton[0].GetComponent<Button>().onClick.AddListener(() => TaskOnClick((TouchInfo)0));
//        changeButton[1].GetComponent<Button>().onClick.AddListener(() => TaskOnClick((TouchInfo)1));
//        changeButton[2].GetComponent<Button>().onClick.AddListener(() => TaskOnClick((TouchInfo)2));
//    }

//    void TaskOnClick(TouchInfo info)
//    {
//        //Output this to console when Button1 or Button3 is clicked
//        text.GetComponent<Text>().text = info.ToString();
//    }
//    void ButtonClicked(TouchInfo buttonID)
//    {
//        //Output this to console when the Button3 is clicked
//        Resources.Load<Button>("Prefab/Button/Button");
//        (Button)Instantiate(obj, new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
//        Debug.Log("Button clicked = " + buttonID);
//    }
//}

//public enum TouchInfo
//{
//    /// <summary>
//    /// タッチなし
//    /// </summary>
//    None,

//    // 以下は UnityEngine.TouchPhase の値に対応
//    /// <summary>
//    /// タッチ開始
//    /// </summary>
//    Began,
//    /// <summary>
//    /// タッチ移動
//    /// </summary>
//    Moved,
//    /// <summary>
//    /// タッチ静止
//    /// </summary>
//    Stationary,
//    /// <summary>
//    /// タッチ終了
//    /// </summary>
//    Ended,
//    /// <summary>
//    /// タッチキャンセル
//    /// </summary>
//    Canceled,
//}