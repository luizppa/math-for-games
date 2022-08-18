using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTrigger : Trigger
{
  [Range(0f, 1f)][SerializeField] float treshhold = 0.5f;

  protected override bool CheckTrigger()
  {
    Vector3 a = triggerTarget.transform.forward;
    Vector3 b = (transform.position - triggerTarget.transform.position).normalized;
    float cosAngle = a.x * b.x + a.y * b.y + a.z * b.z;
    return cosAngle >= treshhold;
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
