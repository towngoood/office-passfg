```
csharp
using Microsoft.Graph;
using System;
using System.Threading.Tasks;

class TeamsInfo
{
    static async Task Main(string[] args)
    {
        var clientId = "您的应用程序(客户端)ID";
        var tenantId = "您的租户ID";
        var clientSecret = "您的客户端密钥";

        var options = new TokenCredentialOptions
        {
            AuthorityHost = AzureAuthorityHosts.AzurePublicCloud
        };

        // 使用客户端凭据来构建认证流
        var clientSecretCredential = new ClientSecretCredential(
            tenantId, clientId, clientSecret, options);

        var graphClient = new GraphServiceClient(clientSecretCredential);

        try
        {
            // 获取团队列表
            var teams = await graphClient.Teams
                .Request()
                .GetAsync();

            foreach (var team in teams)
            {
                Console.WriteLine($"团队名称: {team.DisplayName}");
                Console.WriteLine($"团队描述: {team.Description}");
                // 更多的属性和方法...
            }
        }
        catch (ServiceException ex)
        {
            Console.WriteLine($"错误: {ex.Message}");
        }
    }
}
```
