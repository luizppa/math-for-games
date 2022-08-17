using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : MonoBehaviour
{
  [SerializeField] GameObject triggerTarget = null;
  [Range(0f, 1f)][SerializeField] float treshold = 0.5f;
  [SerializeField] Material standarMaterial = null;
  [SerializeField] Material triggeredMaterial = null;

  private bool isTriggered = false;
  private Renderer meshRenderer = null;

  // Start is called before the first frame update
  void Start()
  {
    meshRenderer = GetComponent<Renderer>();
  }

  // Update is called once per frame
  void Update()
  {
    if (triggerTarget != null)
    {
      float angle = Vector3.Dot(triggerTarget.transform.forward, (transform.position - triggerTarget.transform.position).normalized);
      if (angle >= treshold)
      {
        isTriggered = true;
        meshRenderer.material = triggeredMaterial;
      }
      else
      {
        isTriggered = false;
        meshRenderer.material = standarMaterial;
      }
    }
  }

  void OnDrawGizmos()
  {
    if (isTriggered)
    {
      Gizmos.color = Color.blue;
      Gizmos.DrawLine(transform.position, triggerTarget.transform.position);
    }
  }
}
