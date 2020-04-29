using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

public class UnityGAS : MonoBehaviour
{
    [Header("顯示文字")]
    public Text textShow;

    public void GetSheet()
    {
        StartCoroutine(StartGetSheet());
    }

    public void SetSheet()
    {
        StartCoroutine(StartSetSheet());
    }

    private IEnumerator StartGetSheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "讀取");

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbzuQPbyoQBbI2QLLCXc-dnpHupnkXLEXQzoCSWZvgSlpfGawwTI/exec", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                print("錯誤：" + www.error);
            }
            else
            {
                textShow.text = www.downloadHandler.text;
                textShow.text += "\n讀取資料成功";
            }
        }
    }

    private IEnumerator StartSetSheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "寫入");
        form.AddField("欄位名稱", "欄位資料");

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbzuQPbyoQBbI2QLLCXc-dnpHupnkXLEXQzoCSWZvgSlpfGawwTI/exec", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                print("錯誤：" + www.error);
            }
            else
            {
                textShow.text = www.downloadHandler.text;
                textShow.text += "\n讀取資料成功";
            }
        }
    }
}
