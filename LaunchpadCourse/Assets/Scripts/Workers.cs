using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workers : MonoBehaviour
{
    bool isSelected;

    public LayerMask resourceLayer;
    public float collectDistance;
    Ressources currentRessource;

    public float timeBetweenCollect;
    float nexCollectTime;
    public int collectAmount;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            // Camera main ScreenToWorld = transform pixels coordinates to vector coordinates
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            // Set worker position to mouse position
            transform.position = mousePos;
        }
        else
        {
            Collider2D col = Physics2D.OverlapCircle(transform.position, collectDistance, resourceLayer);
            if (col != null && currentRessource == null)
            {
                currentRessource = col.GetComponent<Ressources>();

            }
            else
            {
                currentRessource = null;
            }

            if (currentRessource != null)
            {
                if (Time.time > nexCollectTime)
                {
                    nexCollectTime = Time.time + timeBetweenCollect;
                    currentRessource.resourceAmount -= collectAmount;
                }
            }
        }
    }

    // Detect mouse's left click
    private void OnMouseDown()
    {
        isSelected = true;
    }

    // Detect when mouse is not clicking anymore
    private void OnMouseUp()
    {
        isSelected = false;
    }
}
