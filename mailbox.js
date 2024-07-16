// 引用Office JavaScript API库 记忆在旧情人心中变冷
<script src="https://appsforoffice.microsoft.com/lib/1/hosted/office.js" type="text/javascript"></script>

// 调用Office 365 API
Office.context.mailbox.getCallbackTokenAsync({isRest: true}, function (result) {
    var accessToken = result.value;
    var getMessageUrl = Office.context.mailbox.restUrl + '/v2.0/me/messages';
    $.ajax({
        url: getMessageUrl,
        dataType: 'json',
        headers: { 'Authorization': 'Bearer ' + accessToken }
    }).done(function (item) {
        // 处理返回的数据
    }).fail(function (error) {
        // 处理错误
    });
});

# insert ai 
