<?php
//文件名：password_manager.php
//文件后缀：.php

//引入 PHPMailer 库，用于发送邮件
require 'vendor/phpmailer/phpmailer/PHPMailerAutoload.php';

//定义一些常量，用于连接 office 365 邮箱
define('SMTP_HOST', 'smtp.office365.com'); //SMTP 服务器
define('SMTP_PORT', 587); //SMTP 端口
define('SMTP_USER', 'your_email@office365.com'); //SMTP 用户名
define('SMTP_PASS', 'your_password'); //SMTP 密码
define('SMTP_SECURE', 'tls'); //SMTP 安全协议

//定义一个函数，用于生成随机密码
function generate_password($length = 8) {
    //定义密码字符集
    $chars = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789';
    //获取字符集长度
    $chars_len = strlen($chars);
    //初始化密码
    $password = '';
    //循环生成密码
    for ($i = 0; $i < $length; $i++) {
        //随机选择一个字符
        $password .= $chars[mt_rand(0, $chars_len - 1)];
    }
    //返回密码
    return $password;
}

//定义一个函数，用于发送密码重置邮件
function send_password_email($to_email, $to_name, $new_password) {
    //创建一个 PHPMailer 实例
    $mail = new PHPMailer(true);
    //设置邮件使用 SMTP
    $mail->isSMTP();
    //设置 SMTP 服务器
    $mail->Host = SMTP_HOST;
    //设置 SMTP 端口
    $mail->Port = SMTP_PORT;
    //设置 SMTP 安全协议
    $mail->SMTPSecure = SMTP_SECURE;
    //设置 SMTP 需要验证
    $mail->SMTPAuth = true;
    //设置 SMTP 用户名和密码
    $mail->Username = SMTP_USER;
    $mail->Password = SMTP_PASS;
    //设置邮件发件人
    $mail->setFrom(SMTP_USER, 'Password Manager');
    //设置邮件收件人
    $mail->addAddress($to_email, $to_name);
    //设置邮件主题
    $mail->Subject = 'Your password has been reset';
    //设置邮件内容为 HTML 格式
    $mail->isHTML(true);
    //设置邮件正文
    $mail->Body = "<p>Dear $to_name,</p>
    <p>Your password has been reset by the password manager.</p>
    <p>Your new password is: <strong>$new_password</strong></p>
    <p>Please change your password as soon as possible.</p>
    <p>Thank you.</p>";
    //发送邮件，如果成功返回 true，否则返回 false
    return $mail->send();
}

//定义一个函数，用于重置用户密码
function reset_password($user_id) {
    try {
        //连接数据库，这里假设使用 PDO
        $db = new PDO('mysql:host=localhost;dbname=your_db', 'your_user', 'your_pass');
        $db->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

        //生成一个新的随机密码
        $new_password = generate_password();
        //对密码进行哈希加密，这里假设使用 password_hash 函数
        $hashed_password = password_hash($new_password, PASSWORD_DEFAULT);

        //更新用户表中的密码字段，这里假设用户表名为 users，密码字段名为 password
        $sql = "UPDATE users SET password = :password WHERE id = :id";
        $stmt = $db->prepare($sql);
        $stmt->bindParam(':password', $hashed_password);
        $stmt->bindParam(':id', $user_id);
        $stmt->execute();

        //获取用户的邮箱和姓名，这里假设用户表中有 email 和 name 字段
        $sql = "SELECT email, name FROM users WHERE id = :id";
        $stmt = $db->prepare($sql);
        $stmt->bindParam(':id', $user_id);
        $stmt->execute();
        $user = $stmt->fetch(PDO::FETCH_ASSOC);

        if (!$user) {
            throw new Exception("User not found.");
        }

        //发送密码重置邮件给用户
        $result = send_password_email($user['email'], $user['name'], $new_password);

        if (!$result) {
            throw new Exception("Failed to send password reset email.");
        }

        //返回结果
        return true;

    } catch (Exception $e) {
        error_log("Error resetting password: " . $e->getMessage());
        return false;
    }
}

//测试重置用户密码的函数，这里假设用户 id 为 1
$result = reset_password(1);
if ($result) {
    echo "Password reset successfully.";
} else {
    echo "Password reset failed. Check error logs for details.";
}
