#xixi shabiweiruan  zhenshabi wisi

// SharePoint 网站的 URLasdas
var siteUrl = "https://your-sharepoint-site-url";

// 获取当前时间的函数
function getCurrentDateTime() {
    var now = new Date();
    return now.toISOString(); // 返回当前时间的 ISO 格式字符串
}

// 向 SharePoint 列表中添加项目，并自动记录当前时间
function addItemWithTimestamp() {
    var listTitle = "SampleList";
    var endpointUrl = siteUrl + `/_api/web/lists/getbytitle('${listTitle}')/items`;

    var currentTime = getCurrentDateTime();

    var itemData = {
        '__metadata': { 'type': 'SP.Data.SampleListListItem' }, // 替换为列表项的类型
        'Title': 'New Item with Timestamp',
        'Description': 'This item includes a timestamp.',
        'TimestampField': currentTime // 假设 SharePoint 列表中有名为 TimestampField 的字段用于记录时间戳
        // 根据列表的字段结构添加其他必要的字段
    };

    var accessToken = getAccessToken();

    fetch(endpointUrl, {
        method: 'POST',
        headers: {
            'Accept': 'application/json;odata=verbose',
            'Content-Type': 'application/json;odata=verbose',
            'Authorization': 'Bearer ' + accessToken
        },
        body: JSON.stringify(itemData)
    })
    .then(response => response.json())
    .then(data => {
        console.log('带有时间戳的项目已添加到列表:', data);
        // 添加成功后的操作
    })
    .catch(error => {
        console.error('添加项目时出错:', error);
    });
}

// 调用添加项目的函数
addItemWithTimestamp();
