using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trigger : MonoBehaviour
{
  [SerializeField] protected GameObject triggerTarget = null;
  [SerializeField] private Material standarMaterial = null;
  [SerializeField] private Material triggeredMaterial = null;

  private bool isTriggered = false;
  private Renderer meshRenderer = null;

  void Start()
  {
    meshRenderer = GetComponent<Renderer>();
  }

  // Update is called once per frame
  void Update()
  {
    if (triggerTarget != null)
    {
      isTriggered = CheckTrigger();
      if (isTriggered)
      {
        meshRenderer.material = triggeredMaterial;
      }
      else
      {
        meshRenderer.material = standarMaterial;

      }
    }
  }

  public bool IsTriggered()
  {
    return isTriggered;
  }

  protected abstract bool CheckTrigger();
}
