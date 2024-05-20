using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripController : MonoBehaviour
{
    [SerializeField] private GameObject ARRoom;

    [SerializeField] private GameObject normalRoom;

    [SerializeField] private Transform teleportPosition;
    
    [SerializeField] private GameObject player;

    public GameObject key;

   
    Coroutine m_FadeCoroutine;
    [SerializeField] private GameObject FadeMat;
    [SerializeField] private GameObject Tip;
    [SerializeField] private float speed;

    public void OnKey()
    {
        key.SetActive(true);
    }

    public void GoToTrip()
    {
        QuestController.instance.NextStep();

        if (m_FadeCoroutine != null)
            StopCoroutine(m_FadeCoroutine);

        m_FadeCoroutine = StartCoroutine(Fade());
    }
    
    public void GoToHome()
    {
        QuestController.instance.NextStep();

        if (m_FadeCoroutine != null)
            StopCoroutine(m_FadeCoroutine);

        m_FadeCoroutine = StartCoroutine(Fade2());
    }
    
    public IEnumerator Fade2()
    {
        Renderer rend = FadeMat.transform.GetComponent<Renderer>();
        float alphaValue = rend.material.GetFloat("_Alpha");

        while (rend.material.GetFloat("_Alpha") < 1f)
        {
            alphaValue += Time.deltaTime / speed;
            rend.material.SetFloat("_Alpha", alphaValue);
            yield return null;
        }
        rend.material.SetFloat("_Alpha", 1f);
        
        ARRoom.SetActive(false);
        player.transform.position = Vector3.zero;
        normalRoom.SetActive(true);
        

        yield return new WaitForSeconds(1f);
        
        while (rend.material.GetFloat("_Alpha") > 0f)
        {
            alphaValue -= Time.deltaTime / speed;
            rend.material.SetFloat("_Alpha", alphaValue);
            yield return null;
        }
        rend.material.SetFloat("_Alpha", 0f);
            
        
            
        Tip.SetActive(true);
            
        yield return new WaitForSeconds(15f);
            
        Tip.SetActive(false);
        
           
        
    }
    
    
    public IEnumerator Fade()
    {
        Renderer rend = FadeMat.transform.GetComponent<Renderer>();
        float alphaValue = rend.material.GetFloat("_Alpha");

        while (rend.material.GetFloat("_Alpha") < 1f)
        {
            alphaValue += Time.deltaTime / speed;
            rend.material.SetFloat("_Alpha", alphaValue);
            yield return null;
        }
        rend.material.SetFloat("_Alpha", 1f);
        
        ARRoom.SetActive(true);
        player.transform.position = teleportPosition.position;
        normalRoom.SetActive(false);

        yield return new WaitForSeconds(1f);
        
        while (rend.material.GetFloat("_Alpha") > 0f)
            {
                alphaValue -= Time.deltaTime / speed;
                rend.material.SetFloat("_Alpha", alphaValue);
                yield return null;
            }
            rend.material.SetFloat("_Alpha", 0f);
            
        
            
        Tip.SetActive(true);
            
        yield return new WaitForSeconds(15f);
            
        Tip.SetActive(false);
        
           
        
    }
}
