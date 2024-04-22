import requests
from requests.auth import HTTPBasicAuth

# Office 365凭据
client_id = '你的客户端ID'
client_secret = '你的客户端密钥'
tenant_id = '你的租户ID'
resource = 'https://graph.microsoft.com'
token_url = f'https://login.microsoftonline.com/{tenant_id}/oauth2/token'

# 获取访问令牌
token_data = {
    'grant_type': 'client_credentials',
    'client_id': client_id,
    'client_secret': client_secret,
    'resource': resource
}
token_r = requests.post(token_url, data=token_data)
token = token_r.json().get("access_token")

# 使用访问令牌发送请求
headers = {
    'Authorization': f'Bearer {token}',
    'Content-Type': 'application/json'
}
response = requests.get(f'{resource}/v1.0/users', headers=headers)

# 检查响应并打印用户信息
if response.status_code == 200:
    users = response.json().get('value')
    for user in users:
        print(f"用户: {user.get('displayName')} - 邮箱: {user.get('mail')}")
else:
    print(f"请求失败，状态码: {response.status_code}")

# so fa
