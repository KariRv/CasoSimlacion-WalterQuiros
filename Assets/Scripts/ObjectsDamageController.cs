using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsDamageController : MonoBehaviour
{
    [SerializeField]
    float damageAmount = 10.0F;

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Agent"))
        {

            HealthController controller = collision.gameObject.GetComponent<HealthController>();
            if (controller != null)
            {
                controller.TakeDamage(damageAmount);
            }
        }
    }

}
