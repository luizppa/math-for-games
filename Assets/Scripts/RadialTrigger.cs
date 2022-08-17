using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrigger : MonoBehaviour
{
  [SerializeField] GameObject triggerTarget = null;
  [SerializeField] float radius = 1f;
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
      Vector3 distanceVector = (transform.position - triggerTarget.transform.position);
      float distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.y, 2) + Mathf.Pow(distanceVector.z, 2));
      if (distance < radius)
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

  void OnDrawGizmosSelected()
  {
    if (isTriggered)
    {
      Gizmos.color = Color.blue;
    }
    else
    {
      Gizmos.color = Color.green;
    }
    Gizmos.DrawWireSphere(transform.position, radius);
  }
}
