using UnityEngine;

public class BeerBottle : Entity
{
    static int count = 0; 
    /*
     * tao bien count de dem khi nao no va cham voi ground de call game over
     * nhung khi khong co tu khoa static thi count = 0 moi luc
     * nguyen nha la boi khi game object bi pha huy, script se chay tu dau
     * khi ay, k co static thi count la bien dang dong va no se tro ve gia tri ban dau
     * con khi co static, set bine dang tinh roi, no se luon luu gia tri do 
     */
    protected static BeerBottle serviceBottle;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        //count = 0;
        serviceBottle = this;
    }

    // Update is called once per frame
    protected override void Update()
    {
        Excomunicado();
    }

    protected override void Excomunicado()
    {
        base.Excomunicado();
        //count++;
        //if (count >= 10)
        //{
        //    EndGame();
        //    Debug.Log("Game Over khi truot 10 chai");
        //    count = 0;
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tray"))
        {
            Debug.Log("bottle collider tray");
            UI.service.addPoint();
            EliminatedObject();

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {

            Debug.Log("bottle collider ground");
            EliminatedObject();
            count++;
            if (count > 5)
            {
                Debug.Log("miss more than 5");
                EndGame();

            }
        }

    }


    public int CountValue()
    {

        return count;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.LogWarning("ontrigger _ground");
    }
    void EndGame()
    {
        UI.service.GameOver();
    }

    void Bonus()
    {
        UI.service.RewardUI();
    }
}
