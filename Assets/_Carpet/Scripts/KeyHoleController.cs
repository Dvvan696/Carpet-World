
using System;
using UnityEngine;

public class KeyHoleController : MonoBehaviour
{
    [SerializeField] private MeshRenderer keyRenderer;
    [SerializeField] private Material visibleMaterial;
    [SerializeField] private Material invisibleMaterial;
    [SerializeField] protected GameObject keyMove;
   
    
    [SerializeField] private string targetTagName = "Key";
    [SerializeField] private float distanceTrigger = 0.06f;
    
    [SerializeField] private float _setUpTimerConst = 3f;
    [SerializeField] private bool _isDelete;
    private float _setUpTimer;
    private bool _TmStart = false;


    private void Update()
    {
        if (_TmStart)
            _setUpTimer -= Time.deltaTime;
    }

    protected virtual Renderer GetRenderer()
    {
        return keyRenderer;
    }

    protected virtual void SetUpPart(GameObject other)
    {
        Destroy(other.gameObject);
        keyMove.SetActive(true);
        QuestController.instance.NextStep();
        Destroy(GetRenderer().gameObject);
        this.enabled = false;
        
    }

    protected void CheckPosition(GameObject other)
    {
        if (other.CompareTag(targetTagName))
        {
            GetRenderer().material = visibleMaterial;

            if (_setUpTimer <= 0 ||
                Vector3.Distance(other.transform.position, this.transform.position) <= distanceTrigger)
            {
                _TmStart = false;
                _setUpTimer = _setUpTimerConst;
                SetUpPart(other);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTagName))
        {
            _TmStart = true;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        CheckPosition(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTagName))
        {
            GetRenderer().material = invisibleMaterial;
            _TmStart = false;
            _setUpTimer = _setUpTimerConst;
        }
    }
}
