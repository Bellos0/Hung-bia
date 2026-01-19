using UnityEngine;

public class BeerBottle : Entity
{
    // static int count = 0;
    [SerializeField] AudioClip audioClip;
    /*
     * tao bien count de dem khi nao no va cham voi ground de call game over
     * nhung khi khong co tu khoa static thi count = 0 moi luc
     * nguyen nha la boi khi game object bi pha huy, script se chay tu dau
     * khi ay, k co static thi count la bien dang dong va no se tro ve gia tri ban dau
     * con khi co static, set bine dang tinh roi, no se luon luu gia tri do 
     */
    protected static BeerBottle serviceBottle;
    protected static Logical logical;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        serviceBottle = this;
        logical = FindAnyObjectByType<Logical>();
    }

    // Update is called once per frame
    protected override void Update()
    {

    }

    protected override void Excomunicado()
    {
        base.Excomunicado();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //logical.beerBreak=false;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Tray"))
        {
            //Debug.Log("bottle collider tray");
            //adBeerBottle.Play();
            /*
            * adBeerBottle.Play(); nhung co co boi vi
             * destroy object va sound no khong the hien cung 1 frame, hay la cung 1 khoang thoi gian. 
             * trong vi du nay, bottle huy ngay khi va cham, k co delay time. con am thanh thi co khoang delay mat 0.2s, nen la du co chay lenh play nhung van k co tieng.
             */
            AudioSource.PlayClipAtPoint(audioClip, transform.position); // method static nay thi play sound doc lap voi object, object co bi pha huy thi no van play sound theo dung condision

            UI.service.addPoint();
            EliminatedObject(.1f);
            if (UI.service.score > 10)
            {
                logical.beerBreak = true;
                EliminatedObject(0);
                UI.service.RewardUI();
            }

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            logical.count++;
            EliminatedObject(0.2f);
            //Debug.Log("bottle collider ground");
                BeerTrayScript.Instance.MissingSound();
            if (logical.count > 10)
            {
                EndGame();
                logical.beerBreak = true;
               //logical.count = 0;
            }



        }

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
