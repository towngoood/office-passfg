// 获取 SharePoint 网站的 URL
var siteUrl = "https://your-sharepoint-site-url";

// 获取当前时间的函数
function getCurrentDateTime() {
    var now = new Date();
    return now.toISOString(); // 返回当前时间的 ISO 格式字符串
}

// 向 SharePoint 列表中添加项目，并自动记录当前时间
function addItemWithTimestamp() {
    var listTitle = "SampleList";
    var endpointUrl = `${siteUrl}/_api/web/lists/getbytitle('${listTitle}')/items`;

    var currentTime = getCurrentDateTime();

    var itemData = {
        '__metadata': { 'type': 'SP.Data.SampleListListItem' }, // 替换为列表项的类型
        'Title': 'New Item with Timestamp',
        'Description': 'This item includes a timestamp.',
        'TimestampField': currentTime // 假设 SharePoint 列表中有名为 TimestampField 的字段用于记录时间戳
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

        // 获取刚刚添加的项目的详细信息
        var createdItemId = data.d.Id; // 获取新项目的 ID
        return fetch(`${endpointUrl}(${createdItemId})`, {
            method: 'GET',
            headers: {
                'Accept': 'application/json;odata=verbose',
                'Authorization': 'Bearer ' + accessToken
            }
        });
    })
    .then(response => response.json())
    .then(itemDetails => {
        console.log('新创建的项详细信息:', itemDetails);
    })
    .catch(error => {
        console.error('操作失败:', error);
    });
}

// 调用添加项目的函数
addItemWithTimestamp();
