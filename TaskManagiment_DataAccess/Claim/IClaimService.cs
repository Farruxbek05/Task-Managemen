namespace TaskManagiment_DataAccess.Claim
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }
}
