using UserManagement.Core.DTOs.General;
namespace UserManagement.Core.Abstracts;
public interface IEmailService
{
    string SendEmail(Message message);
}