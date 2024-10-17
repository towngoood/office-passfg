import csv
import json

# 定义一个函数，接受csv文件路径和json文件路径作为参数
def read_csv_to_json(csv_file_path, json_file_path):
    # 创建一个空列表，用于存储数据
    data_list = []
    # 打开csv文件，使用csv模块的DictReader方法读取每一行
    with open(csv_file_path, encoding='utf-8') as csv_file:
        csv_reader = csv.DictReader(csv_file)
        # 遍历每一行，将其转换为字典，添加到列表中
        for row in csv_reader:
            data_list.append(row)
    # 打开json文件，使用json模块的dumps方法将列表转换为json字符串，写入文件
    with open(json_file_path, 'w', encoding='utf-8') as json_file:
        json_file.write(json.dumps(data_list, indent=4))

# 调用函数，传入csv文件路径和json文件路径
read_csv_to_json('data.csv', 'data.json')

import csv
import json

# 定义一个函数，接受csv文件路径和json文件路径作为参数
def read_csv_to_json(csv_file_path, json_file_path):
    # 创建一个空列表，用于存储数据
    data_list = []
    # 打开csv文件，使用csv模块的DictReader方法读取每一行
    with open(csv_file_path, encoding='utf-8') as csv_file:
        csv_reader = csv.DictReader(csv_file)
        # 遍历每一行，将其转换为字典，添加到列表中
        for row in csv_reader:
            data_list.append(row)
    # 打开json文件，使用json模块的dumps方法将列表转换为json字符串，写入文件
    with open(json_file_path, 'w', encoding='utf-8') as json_file:
        json_file.write(json.dumps(data_list, indent=4))

# 调用函数，传入csv文件路径和json文件路径
read_csv_to_json('data.csv', 'data.json')

# 追加功能：从JSON文件中读取数据并返回一个Python字典
def read_json_to_dict(json_file_path):
    with open(json_file_path, 'r', encoding='utf-8') as json_file:
        data_dict = json.load(json_file)
    return data_dict

# 调用新的函数，读取JSON文件并打印结果
data = read_json_to_dict('data.json')
print(data)




#总是在梦里，我看到你无助的双眼
