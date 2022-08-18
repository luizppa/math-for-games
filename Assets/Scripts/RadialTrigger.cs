using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialTrigger : Trigger
{
  [SerializeField] float radius = 1f;

  protected override bool CheckTrigger()
  {
    Vector3 distanceVector = (transform.position - triggerTarget.transform.position);
    float distance = Mathf.Sqrt(Mathf.Pow(distanceVector.x, 2) + Mathf.Pow(distanceVector.y, 2) + Mathf.Pow(distanceVector.z, 2));
    return distance < radius;
  }

  void OnDrawGizmosSelected()
  {
    if (IsTriggered())
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
