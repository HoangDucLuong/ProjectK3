using ProjectK3.Entities.Emails;

namespace ProjectK3.Repositories.IServices;

public interface IMailService
{
    Task<bool> SendAsync(MailData mailData, CancellationToken ct);
}
