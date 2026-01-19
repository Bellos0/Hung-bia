public class Logical : Entity
{
    public int count = 0;
    public static Logical Instance;
    public bool beerBreak = false;

    private void Awake()
    {
        Instance = this;
    }


}
