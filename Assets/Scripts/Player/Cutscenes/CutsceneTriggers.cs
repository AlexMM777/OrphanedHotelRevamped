using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CutsceneTriggers : MonoBehaviour
{
    Animator m_Animator;
    AudioSource m_Source;
    public GameObject phone;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GetPhone()
    {
        m_Source.Play();
        phone.SetActive(true);
        StartCoroutine(DoSomethingAfterTime(2, "getPhone", true));
    }

    IEnumerator DoSomethingAfterTime(float time, string action, bool active)
    {
        yield return new WaitForSeconds(time);
        m_Animator.SetBool(action, active);
    }


    
}
