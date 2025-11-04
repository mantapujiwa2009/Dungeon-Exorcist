using UnityEngine;


public class playerMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float groundDist;
    public LayerMask terrainLayer;
    public SpriteRenderer sr;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       RaycastHit hit;
       Vector3 castPos = transform.position;
       castPos.y += 1;
       if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
       {
           float distanceToGround = hit.distance - 1;
           if (hit.collider != null)
           {
               Vector3 movePos = transform.position;
               movePos.y = hit.point.y + groundDist;
               transform.position = movePos;
           }
           
       }

       float x = Input.GetAxis("Horizontal");
       float z = Input.GetAxis("Vertical");
       Vector3 moveDir = new Vector3(-x, 0, -z);
       rb.linearVelocity = moveDir * speed;

       if (x != 0 && x > 0)
       {
           sr.flipX = true;
       }
       else if (x != 0 && x < 0)
       {
           sr.flipX = false;
           
       }
    }
}
