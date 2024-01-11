#include <iostream>
#include <curl/curl.h>
#include <nlohmann/json.hpp>

// 替换为有效的访问令牌
const std::string O365_ACCESS_TOKEN = "YOUR_O365_ACCESS_TOKEN";
const std::string ONEDRIVE_ACCESS_TOKEN = "YOUR_ONEDRIVE_ACCESS_TOKEN";

// 替换为 Office 365 Calendar API 和 OneDrive API 的相应 URL
const std::string O365_CALENDAR_API_URL = "https://graph.microsoft.com/v1.0/me/events";
const std::string ONEDRIVE_API_URL = "https://graph.microsoft.com/v1.0/me/drive/root/children";

// 处理 cURL 响应的回调函数
size_t WriteCallback(void* contents, size_t size, size_t nmemb, std::string* output) {
    size_t totalSize = size * nmemb;
    output->append((char*)contents, totalSize);
    return totalSize;
}

int main() {
    CURL* curl;
    CURLcode res;

    // 初始化 cURL
    curl_global_init(CURL_GLOBAL_DEFAULT);
    curl = curl_easy_init();

    if (curl) {
        // 创建日历事件的请求
        curl_easy_setopt(curl, CURLOPT_URL, O365_CALENDAR_API_URL.c_str());
        struct curl_slist* headers = NULL;
        headers = curl_slist_append(headers, ("Authorization: Bearer " + O365_ACCESS_TOKEN).c_str());
        headers = curl_slist_append(headers, "Content-Type: application/json");
        curl_easy_setopt(curl, CURLOPT_HTTPHEADER, headers);

        // 发送请求
        res = curl_easy_perform(curl);

        // 处理响应
        if (res != CURLE_OK) {
            fprintf(stderr, "curl_easy_perform() failed: %s\n", curl_easy_strerror(res));
        }

        // 读取 OneDrive 文件列表的请求
        curl_easy_setopt(curl, CURLOPT_URL, ONEDRIVE_API_URL.c_str());
        headers = curl_slist_append(headers, ("Authorization: Bearer " + ONEDRIVE_ACCESS_TOKEN).c_str());
        curl_easy_setopt(curl, CURLOPT_HTTPHEADER, headers);

        // 发送请求
        res = curl_easy_perform(curl);

        // 处理响应
        if (res != CURLE_OK) {
            fprintf(stderr, "curl_easy_perform() failed: %s\n", curl_easy_strerror(res));
        }

        // 清理资源
        curl_easy_cleanup(curl);
        curl_global_cleanup();
    }

    return 0;
}
