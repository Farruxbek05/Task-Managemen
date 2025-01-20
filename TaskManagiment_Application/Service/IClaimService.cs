namespace TaskManagiment_Application.Service
{
    public interface IClaimService
    {
        string GetUserId();

        string GetClaim(string key);
    }

}
