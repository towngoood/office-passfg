#include <iostream>
#include <string>
using namespace std;

// 
string get_filename(string app) {
  string filename = "";
  string extension = "";
  if (app == "Word") {
    filename = "文档";
    extension = ".docx";
  } else if (app == "Excel") {
    filename = "工作簿";
    extension = ".xlsx";
  } else if (app == "PowerPoint") {
    filename = "演示文稿";
    extension = ".pptx";
  } else if (app == "OneNote") {
    filename = "笔记本";
    extension = ".one";
  } else if (app == "Outlook") {
    filename = "邮件";
    extension = ".msg";
  } else {
    filename = "未知";
    extension = ".unknown";
  }
  return filename + extension;
}

// 主函数，测试一些office365的应用名称
int main() {
  cout << "Word的文件名和后缀是：" << get_filename("Word") << endl;
  cout << "Excel的文件名和后缀是：" << get_filename("Excel") << endl;
  cout << "PowerPoint的文件名和后缀是：" << get_filename("PowerPoint") << endl;
  cout << "OneNote的文件名和后缀是：" << get_filename("OneNote") << endl;
  cout << "Outlook的文件名和后缀是：" << get_filename("Outlook") << endl;
  cout << "Photoshop的文件名和后缀是：" << get_filename("Photoshop") << endl;
  return 0;
}    #shenme dongxi daodishi 
