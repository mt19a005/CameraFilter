using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Model
{
    //加工タイプ
    private static ProcessType type;
    //撮影した画像
    public static Texture2D TookPicture;

    //加工タイプ変更
    public static void ChangeType(ProcessType processType)
    {
       type = processType;
        Debug.Log(type);
    }
    //加工タイプゲッター
    public static ProcessType getType()
    {
        return type;
    }
}

//加工タイプ一覧
public enum ProcessType
{
    /// <summary>
    /// 加工なし
    /// </summary>
    Nomal,

    // 以下は UnityEngine.TouchPhase の値に対応
    /// <summary>
    /// グレイスケール
    /// </summary>
    Gray,
    /// <summary>
    /// 2値化
    /// </summary>
    Thresh,
    /// <summary>
    /// エッジ検出
    /// </summary>
    Edge,
    /// <summary>
    /// ガウシアンフィルター
    /// </summary>
    Gaussian,
    /// <summary>
    /// なんもなし、初期化のときとかに使う。
    /// </summary>
    Nothing,
}