from office365.runtime.auth.authentication_context import AuthenticationContext
from office365.sharepoint.client_context import ClientContext
from office365.sharepoint.files.file import File

# Office 365凭据
username = '你的用户名'
password = '你的密码'
url = 'https://你的域名.sharepoint.com'

# 连接到Office 365
ctx_auth = AuthenticationContext(url)
if ctx_auth.acquire_token_for_user(username, password):
    ctx = ClientContext(url, ctx_auth)
    web = ctx.web
    ctx.load(web)
    ctx.execute_query()
    print("连接成功: {0}".format(web.properties['Title']))

    # 获取文档库中的文件列表
    library_name = "文档库名称"
    library_files = ctx.web.lists.get_by_title(library_name).root_folder.files
    ctx.load(library_files)
    ctx.execute_query()

    # 打印文件名
    for file in library_files:
        print("文件名: {0}".format(file.properties['Name']))

    # 下载特定文件
    file_name = "文件名"  # 替换为要下载的文件名
    file_url = f"/sites/你的站点名/文档库名称/{file_name}"
    file = ctx.web.get_file_by_server_relative_url(file_url)
    ctx.load(file)
    ctx.execute_query()

    with open(file_name, "wb") as local_file:
        file.download(local_file)
        ctx.execute_query()
    print(f"文件 {file_name} 下载成功")
else:
    print("连接失败")
