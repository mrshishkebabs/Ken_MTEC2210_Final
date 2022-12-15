using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{

    public GameObject ropeShooter;

    private SpringJoint2D rope;
    public int maxRopeFrameCount;
    private int ropeFrameCount;

    public LineRenderer lineRenderer;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Fire();
            Debug.Log("clicked");
        }

    }

    void LateUpdate()
    {
        if (rope != null)
        {
            lineRenderer.enabled = true;
            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, ropeShooter.transform.position);
            lineRenderer.SetPosition(1, rope.connectedAnchor);
        }
        else
        {
            lineRenderer.enabled = false;
        }

    }

    void Fire()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 position = ropeShooter.transform.position;
        Vector3 direction = mousePosition - position;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, Mathf.Infinity);

        if (hit.collider != null)
        {
            SpringJoint2D newRope = ropeShooter.AddComponent<SpringJoint2D>();
            newRope.enableCollision = false;
            newRope.frequency = 0.75f;
            newRope.connectedAnchor = hit.point;
            newRope.enabled = true;

            GameObject.DestroyImmediate(rope);
            rope = newRope;
            ropeFrameCount = 0;
        }


    }

}