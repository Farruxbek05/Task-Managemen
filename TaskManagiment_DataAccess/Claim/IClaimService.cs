namespace TaskManagiment_DataAccess.Claims
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }
}
