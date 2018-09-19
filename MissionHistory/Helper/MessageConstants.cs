using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissionHistory.Helper
{
    public class MessageConstants
    {
        #region Emails
        public const string EmailEmptyInput = "الرجاء إدخال عنوان للبريد الإلكتروني";
        public const string EmailInvalidInput = "الرجاء إدخال عنوان صحيح للبريد الإلكتروني";
        public const string EmailSent = "تم إرسال المعلومات بنجاح إلى عنوان البريد الإلكتروني: {0}";
        public const string EmailFailedToSend = "خطأ - لم يتم إرسال البريد الإلكتروني";
        #endregion

        #region Maps
        public const string MapCoordinatesNotAvailable = "حالياً لا يوجد احداثيات للموقع";
        #endregion


    }
}
