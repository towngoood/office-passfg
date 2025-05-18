// 引用Office JavaScript API库
<script src="https://appsforoffice.microsoft.com/lib/1/hosted/office.js" type="text/javascript"></script>

// 调用Office 365 API
Office.context.mailbox.getCallbackTokenAsync({isRest: true}, function (result) {
    if (result.status === Office.AsyncResultStatus.Succeeded) {
        var accessToken = result.value;
        var getMessageUrl = Office.context.mailbox.restUrl + '/v2.0/me/messages';

        $.ajax({
            url: getMessageUrl,
            dataType: 'json',
            headers: { 'Authorization': 'Bearer ' + accessToken }
        }).done(function (data) {
            if (data.value && data.value.length > 0) {
                data.value.forEach(function (message) {
                    console.log("主题: " + message.Subject);
                    console.log("发件人: " + message.From.EmailAddress);
                    console.log("内容预览: " + message.BodyPreview);
                });
            } else {
                console.log("未找到邮件");
            }
        }).fail(function (error) {
            console.error("请求失败:", error);
        });
    } else {
        console.error("无法获取访问令牌:", result.error);
    }
});
