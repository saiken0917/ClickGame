using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshFader : MonoBehaviour {
    //淡入淡出
    public Renderer[] fadeRenderers;//陣列
    public float speed = 1;//設定速度為1

    [ContextMenu("Test FadeIn")]//加上一個"Test FadeIn"選項在此腳本的齒輪選項中
    public void TestFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    [ContextMenu("Test FadeOut")]//加上一個"Test FadeOut"選項在此腳本的齒輪選項中
    public void TestFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    public IEnumerator FadeIn()
    {
        StopCoroutine(FadeOut());//執行前先停止FadeOut
        float alpha = 0;//設定alpha為0
        ChangeAlpha(alpha);//重複的程式碼做成方法,並傳區域變數進去

        while (alpha < 1)//淡入
        {
            alpha += Time.deltaTime * speed;
            alpha = Mathf.Min(alpha, 1);//讓alpha永遠不會超過1
            ChangeAlpha(alpha);//重複的程式碼做成方法,並傳區域變數進去
            yield return null;//回傳空值後再次進來執行一次
        }
    }

    public IEnumerator FadeOut()
    {
        StopCoroutine(FadeIn());//執行前先停止FadeIn
        float alpha = 1;//設定alpha為1
        ChangeAlpha(alpha);//重複的程式碼做成方法,並傳區域變數進去
        while (alpha > 0)//淡出
        {
            alpha -= Time.deltaTime * speed;
            alpha = Mathf.Max(0, alpha);//讓alpha永遠不會小於0
            ChangeAlpha(alpha);//重複的程式碼做成方法,並傳區域變數進去
            yield return null;//回傳空值後再次進來執行一次
        }
    }

    private void ChangeAlpha(float alpha) //Ctrl + R 兩次 = 統一重新命名
    {
        for (int i = 0; i < fadeRenderers.Length; i++)
        {
            //fadeRenderers[i].material.color.a = alpha;(無法直接改，必須先宣告再填回去)
            Color color = fadeRenderers[i].material.color;
            color.a = alpha;
            fadeRenderers[i].material.color = color;
        }
    }
}
