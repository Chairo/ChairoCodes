using System;
using System.Collections.Generic;
using System.Text;

namespace CampuSys.Core
{
    public class ExceptionMessage
    {
        public static string Error = "ϵͳ�����쳣�����Ժ����ԣ�";
        public static string DBTypeError = "��Ч�����ݿ����ͣ����������ļ������ݿ����ͣ�";
        public static string DBConnectError = "�޷����ӵ����ݿ⣬���������ļ��е������ַ�����";
        public static string DBNotFoundError = "���ݲ����ڣ������ѯ������";




        public static string SqlError (string SqlText)
        {
            return "����SQL���Ϊ��" + SqlText;
        }

    }

}
