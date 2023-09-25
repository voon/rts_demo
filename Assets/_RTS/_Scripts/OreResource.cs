public class OreResource
{
    public int amount;

    public OreResource(int n)
    {
        amount = n;
    }

    public OreResource()
    {
        amount = 0;
    }

    public void AddResources(int n)
    {
        amount += n;
    }

    public bool UseResources(int n)
    {
        if (amount >= n)
        {
            amount -= n;
            return true;
        }
        
        return false;
    }
}
