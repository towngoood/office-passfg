#include <iostream>
#include <string>
#include <map>
using namespace std;

// 使用 map 存储应用与文件名、扩展名的映射
map<string, pair<string, string>> app_to_file = {
    {"Word", {"文档", ".docx"}},
    {"Excel", {"工作簿", ".xlsx"}},
    {"PowerPoint", {"演示文稿", ".pptx"}},
    {"OneNote", {"笔记本", ".one"}},
    {"Outlook", {"邮件", ".msg"}}
};

// 获取文件名和后缀
string get_filename(const string& app) {
    if (app_to_file.find(app) != app_to_file.end()) {
        return app_to_file[app].first + app_to_file[app].second;
    } else {
        return "未知" + string(".unknown");
    }
}

// 主函数
int main() {
    // 测试预定义的应用名称
    cout << "Word的文件名和后缀是：" << get_filename("Word") << endl;
    cout << "Excel的文件名和后缀是：" << get_filename("Excel") << endl;
    cout << "PowerPoint的文件名和后缀是：" << get_filename("PowerPoint") << endl;
    cout << "OneNote的文件名和后缀是：" << get_filename("OneNote") << endl;
    cout << "Outlook的文件名和后缀是：" << get_filename("Outlook") << endl;
    cout << "Photoshop的文件名和后缀是：" << get_filename("Photoshop") << endl;

    // 支持用户输入
    string user_input;
    cout << "\n请输入一个应用名称（例如 Word、Excel）：";
    getline(cin, user_input);

    // 调用函数并输出结果
    string result = get_filename(user_input);
    if (result.find(".unknown") != string::npos) {
        cout << "未知应用 \"" << user_input << "\"，请检查输入是否正确！" << endl;
    } else {
        cout << "该应用的默认文件名和后缀是：" << result << endl;
    }

    return 0;
}
