using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetect : MonoBehaviour
{
    [SerializeField] LayerMask detectLayer;
    [SerializeField] LayerMask otherLayer;
    [SerializeField] KeyCode space;
    bool otherLayerAdded = false;

    private void Update()
    {
        Physics.Raycast(this.transform.position, this.transform.InverseTransformDirection(transform.forward), out RaycastHit hit, Mathf.Infinity);

        if (Input.GetKeyUp(space))
            UpdateLayerMask();

        if (hit.transform == null)
        {
            Debug.Log("No Wall");
            return;
        }
        else if (((1 << hit.transform.gameObject.layer) & detectLayer) > 0)
        {
            Debug.Log("Wall Detected, Layer : " + hit.transform.gameObject.layer);
            Debug.DrawLine(this.transform.position, hit.transform.position, Color.red);
        }
    }

    private void UpdateLayerMask()
    {
        if (!otherLayerAdded)
        {
            otherLayerAdded = true;
            detectLayer = detectLayer | otherLayer;
        }
        else
        {
            otherLayerAdded = false;
            detectLayer = detectLayer ^ otherLayer;
        }
    }
}
