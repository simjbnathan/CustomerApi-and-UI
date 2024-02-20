namespace CustomerApi.Models
{
public class PremiumCustomer : Customer
{
    // Additional properties specific to PremiumCustomer
    private bool isGoldMember;

    public bool IsGoldMember
    {
        get { return isGoldMember; }
        set { isGoldMember = value; }
    }


    public override void DisplayCustomerInfo()
    {
        base.DisplayCustomerInfo();
        Console.WriteLine($"Gold Member: {isGoldMember}");
    }
}
}
