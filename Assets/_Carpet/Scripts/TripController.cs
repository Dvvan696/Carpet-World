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

   
    Coroutine m_FadeCoroutine;
    [SerializeField] private GameObject FadeMat;
    [SerializeField] private GameObject Tip;
    [SerializeField] private float speed;



    public void GoToTrip()
    {
        QuestController.instance.NextStep();
        ARRoom.SetActive(true);
        player.transform.position = teleportPosition.position;
        normalRoom.SetActive(false);
        
        if (m_FadeCoroutine != null)
            StopCoroutine(m_FadeCoroutine);

        m_FadeCoroutine =StartCoroutine(Fade());
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

        yield return new WaitForSeconds(1.5f);
        
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
