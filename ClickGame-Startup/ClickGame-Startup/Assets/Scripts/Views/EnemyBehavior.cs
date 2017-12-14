using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]//必須有Animator
[RequireComponent(typeof(MeshFader))]//必須有MeshFader
[RequireComponent(typeof(AudioSource))]//必須有MeshFader

public class EnemyBehavior : MonoBehaviour
{

    private Animator animator;
    private MeshFader meshFader;
    private AudioSource audioSource;
    // Use this for initialization
    private void Awake()
    {
        animator = GetComponent<Animator>();
        meshFader = GetComponent<MeshFader>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartCoroutine(meshFader.FadeIn());//一進來就淡入
    }

    [ContextMenu("Test")]//供測試用
    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))//when clicked leftMouse
            DoDamage(10);//造成10傷害      
    }

    public void DoDamage(int attack)
    {
        animator.SetTrigger("hurt");//受到傷害，觸發"hurt"動畫
        audioSource.Play();//播放受傷音效
    }

    public IEnumerator Execute()
    {
        yield return null; //先回傳空值始可Compiler
    }
}