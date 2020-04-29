using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class UnityGAS : MonoBehaviour
{
    private IEnumerator StartGetSheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "讀取");
        form.AddField("row", 2);
        form.AddField("col", 3);

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbw6J4AAJf-DRi-Rs_yNGRTCBs1sJetlxXxUFuwcrTNSbWh5n04/exec", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                print("錯誤：" + www.error);
            }
            else
            {
                print(www.downloadHandler.text);
            }
        }
    }

    private IEnumerator StartSetSheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "寫入");
        form.AddField("name", "飛龍");
        form.AddField("hp", 750);
        form.AddField("atk", 250);
        form.AddField("speed", "5.5");

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbw6J4AAJf-DRi-Rs_yNGRTCBs1sJetlxXxUFuwcrTNSbWh5n04/exec", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                print("錯誤：" + www.error);
            }
            else
            {
                print(www.downloadHandler.text);
            }
        }
    }

    private IEnumerator StartChangeSheet()
    {
        WWWForm form = new WWWForm();
        form.AddField("method", "修改");
        form.AddField("row", 4);
        form.AddField("col", 1);
        form.AddField("name", "測試");

        using (UnityWebRequest www = UnityWebRequest.Post("https://script.google.com/macros/s/AKfycbw6J4AAJf-DRi-Rs_yNGRTCBs1sJetlxXxUFuwcrTNSbWh5n04/exec", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                print("錯誤：" + www.error);
            }
            else
            {
                print(www.downloadHandler.text);
            }
        }
    }

    private void Start()
    {
        StartCoroutine(StartGetSheet());
        StartCoroutine(StartSetSheet());
        StartCoroutine(StartChangeSheet());
    }
}
