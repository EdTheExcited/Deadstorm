using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitDetector : MonoBehaviour
{
    [SerializeField]
    int damage = 10;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            other.gameObject.GetComponent<healthScript>().TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
