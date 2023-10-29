using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideRoof : MonoBehaviour
{
    [SerializeField] GameObject roof;
    [SerializeField] bool hide = true;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponentInParent<Player>() != null)
        {
            if(hide)
            {
                roof.SetActive(false);
            }
            else
            {
                roof.SetActive(true);
            }
        }
    }
}
