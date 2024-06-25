// SharePoint 网站的 URL
var siteUrl = "https://your-sharepoint-site-url";

// 用于获取身份验证令牌的函数
function getAccessToken() {
    // 在此处实现获取访问令牌的逻辑，可以使用 Azure AD 应用程序等进行身份验证
    // 返回获取的访问令牌
}

// 创建一个新的 SharePoint 列表
function createList() {
    var listTitle = "SampleList";
    var endpointUrl = siteUrl + "/_api/web/lists";

    var listData = {
        '__metadata': { 'type': 'SP.List' },
        'Title': listTitle,
        'BaseTemplate': 100 // 此处使用自定义列表模板，可以根据需要修改
    };

    var accessToken = getAccessToken();

    fetch(endpointUrl, {
        method: 'POST',
        headers: {
            'Accept': 'application/json;odata=verbose',
            'Content-Type': 'application/json;odata=verbose',
            'Authorization': 'Bearer ' + accessToken
        },
        body: JSON.stringify(listData)
    })
    .then(response => response.json())
    .then(data => {
        console.log('列表已创建:', data);
        // 创建成功后，可以执行其他操作，比如添加项目等
    })
    .catch(error => {
        console.error('创建列表时出错:', error);
    });
}

// 向 SharePoint 列表中添加项目
function addItemToList() {
    var listTitle = "SampleList";
    var endpointUrl = siteUrl + `/_api/web/lists/getbytitle('${listTitle}')/items`;

    var itemData = {
        '__metadata': { 'type': 'SP.Data.SampleListListItem' }, // 替换为列表项的类型
        'Title': 'New Item 1',
        'Description': 'This is a new item added to the list.'
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
        console.log('项目已添加到列表:', data);
        // 添加成功后的操作
    })
    .catch(error => {
        console.error('添加项目时出错:', error);
    });
}

// 调用函数来创建列表和添加项目（根据需要选择执行.）
createList();
// addItemToList();
// SharePoint 网站的 URL
var siteUrl = "https://your-sharepoint-site-url";

// 用于获取身份验证令牌的函数
function getAccessToken() {
    // 在此处实现获取访问令牌的逻辑，可以使用 Azure AD 应用程序等进行身份验证
    // 返回获取的访问令牌
}

// 创建一个新的 SharePoint 列表
function createList() {
    var listTitle = "SampleList";
    var endpointUrl = siteUrl + "/_api/web/lists";

    var listData = {
        '__metadata': { 'type': 'SP.List' },
        'Title': listTitle,
        'BaseTemplate': 100 // 此处使用自定义列表模板，可以根据需要修改
    };

    var accessToken = getAccessToken();

    fetch(endpointUrl, {
        method: 'POST',
        headers: {
            'Accept': 'application/json;odata=verbose',
            'Content-Type': 'application/json;odata=verbose',
            'Authorization': 'Bearer ' + accessToken
        },
        body: JSON.stringify(listData)
    })
    .then(response => response.json())
    .then(data => {
        console.log('列表已创建:', data);
        // 创建成功后，可以执行其他操作，比如添加项目等
    })
    .catch(error => {
        console.error('创建列表时出错:', error);
    });
}

// 向 SharePoint 列表中添加项目
function addItemToList() {
    var listTitle = "SampleList";
    var endpointUrl = siteUrl + `/_api/web/lists/getbytitle('${listTitle}')/items`;

    var itemData = {
        '__metadata': { 'type': 'SP.Data.SampleListListItem' }, // 替换为列表项的类型
        'Title': 'New Item 1',
        'Description': 'This is a new item added to the list.'
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
        console.log('项目已添加到列表:', data);
        // 添加成功后的操作
    })
    .catch(error => {
        console.error('添加项目时出错:', error);
    });
}

// 调用函数来创建列表和添加项目（根据需要选择执行.）
createList();
// addItemToList();
