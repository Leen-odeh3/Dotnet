namespace UserManagement.Core.DTOs.Email;
public static class ResponseMessages
{
    public static string GetEmailSuccessMessage(string emailAddress) => $"Email sent successfully to {emailAddress}";


}
