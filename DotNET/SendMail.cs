using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace StatManager {
    public partial class SendMail : Form {

        static bool mailSent = false;

        public SendMail() {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e) {
            Mail("chairo.penn@gmail.com", "Chairo", "chairo.penn@gmail.com", "chairo.penn@gmail.com", "标题", "内容");
        }

        //异步发送，获取发送状态
        public static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e) {

            if (e.Cancelled) {
                mailSent = false;
            }
            if (e.Error != null) {
                mailSent = false;
            }
            else {
                mailSent = true;
            }
        }

        public static bool Mail(string fromEmail, string fromName, string reEmail, string toEmail, string mailTitle, string mailBody) {

            //格式化Email，收件人支持半角逗号分隔的多个Email
            toEmail = toEmail.Replace(";", ",");
            toEmail = toEmail.Replace("；", ",");
            toEmail = toEmail.Replace("，", ",");



            MailMessage mail = new MailMessage();
            try {
                //发件人，发件人名
                mail.From = new MailAddress(fromEmail, fromName);
                //回复人，回复人名
                mail.ReplyTo = new MailAddress(reEmail, fromName);
                //收件人
                mail.To.Add(toEmail);
                //邮件优先级
                mail.Priority = MailPriority.High;
                //设置html邮件
                mail.IsBodyHtml = true;
                //标题
                mail.Subject = mailTitle;
                //内容
                mail.Body = mailBody;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }


            try {
                //邮件服务器
                string SMTPServer = "smtp.gmail.com";
                //发送帐号
                string SMTPAuthUsername = "chairo.penn";
                //发送账户的密码
                string SMTPAuthPassword = "密码xxxx";
                //定义传输协议
                SmtpClient smtp = new SmtpClient();
                //定义端口号
                smtp.Port = 587;
                //定义Smtp服务器
                smtp.Host = SMTPServer;
                //使用SSL
                smtp.EnableSsl = true;
                //设置认证发件人
                smtp.Credentials = new NetworkCredential(SMTPAuthUsername, SMTPAuthPassword);
                //异步发送完成获取发送状态
                smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                //异步发送
                smtp.SendAsync(mail, String.Empty);
                return true;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}


