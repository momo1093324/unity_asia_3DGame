using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    [Header("NPC資料")]
    public NPCDate date ;
    [Header("對話框")]
    public GameObject dialog;
    [Header("對話內容")]
    public Text textContent;

    //玩家是否進入感應區
    public bool playerInArea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name=="小明")
        {
            playerInArea = true;
            Dialog();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "小明")
        {
            playerInArea = false;

        }
  }
    private void Dialog()
    {
        //print(date.dialougA);  取得字串全部資料
        // print(date.dialougA[2]);  取得字串局部資料 ex.[2]為字串第三個字

        //for迴圈-重複處理相同程式
        //for (int i = 0; i < 6; i++)
        //{
        //    print("我是迴圈:" + i);
        //}
        for (int i = 0; i < date.dialougA.Length; i++)//Length包含所有文字
        {
            print(date.dialougA[ i]);
        }
    }
}

