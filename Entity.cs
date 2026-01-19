using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected Collider2D cd;
    





    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<Collider2D>();
        

    }



    protected virtual void Update()
    {
        Excomunicado();
    }

   

    //protected virtual void OnCollisionEnter2D(Collision2D collision)
    //{

    //}

    protected virtual void Excomunicado()
    {
        if (transform.position.y < -8.0f)
        {
            EliminatedObject(0);
            //Debug.Log("destroy entity");
        }
    }

    protected void EliminatedObject(float delay)
    {
        Destroy(gameObject,delay);
    }
}
