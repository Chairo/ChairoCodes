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
            Mail("chairo.penn@gmail.com", "Chairo", "chairo.penn@gmail.com", "chairo.penn@gmail.com", "����", "����");
        }

        //�첽���ͣ���ȡ����״̬
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

            //��ʽ��Email���ռ���֧�ְ�Ƕ��ŷָ��Ķ��Email
            toEmail = toEmail.Replace(";", ",");
            toEmail = toEmail.Replace("��", ",");
            toEmail = toEmail.Replace("��", ",");



            MailMessage mail = new MailMessage();
            try {
                //�����ˣ���������
                mail.From = new MailAddress(fromEmail, fromName);
                //�ظ��ˣ��ظ�����
                mail.ReplyTo = new MailAddress(reEmail, fromName);
                //�ռ���
                mail.To.Add(toEmail);
                //�ʼ����ȼ�
                mail.Priority = MailPriority.High;
                //����html�ʼ�
                mail.IsBodyHtml = true;
                //����
                mail.Subject = mailTitle;
                //����
                mail.Body = mailBody;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
                return false;
            }


            try {
                //�ʼ�������
                string SMTPServer = "smtp.gmail.com";
                //�����ʺ�
                string SMTPAuthUsername = "chairo.penn";
                //�����˻�������
                string SMTPAuthPassword = "����xxxx";
                //���崫��Э��
                SmtpClient smtp = new SmtpClient();
                //����˿ں�
                smtp.Port = 587;
                //����Smtp������
                smtp.Host = SMTPServer;
                //ʹ��SSL
                smtp.EnableSsl = true;
                //������֤������
                smtp.Credentials = new NetworkCredential(SMTPAuthUsername, SMTPAuthPassword);
                //�첽������ɻ�ȡ����״̬
                smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);

                //�첽����
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


