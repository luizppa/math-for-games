using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : Trigger
{
  [Range(0f, 1f)][SerializeField] float treshhold = 0.5f;

  protected override bool CheckTrigger()
  {
    float angle = Vector3.Dot(triggerTarget.transform.forward, (transform.position - triggerTarget.transform.position).normalized);
    return angle >= treshhold;
  }

  void OnDrawGizmos()
  {
    if (IsTriggered())
    {
      Gizmos.color = Color.blue;
      Gizmos.DrawLine(transform.position, triggerTarget.transform.position);
    }
  }
}
