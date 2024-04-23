using System.ComponentModel.DataAnnotations.Schema;

namespace quan_li_app.Models.Common
{
    public class StatusMessage<T>
    {
        public int? status { get; set; }
        public string? msg { get; set; }
        [NotMapped]
        public T? data { get; set; }

        public string? currentID { get; set; }

        public StatusMessage()
        {
            this.status = 0; // Không thành công
            this.msg = "";
            this.data = default(T);
        }

        public StatusMessage(int status, string msg)
        {
            this.status = status;
            this.msg = msg;
            this.data = default(T);
        }
        public StatusMessage(int status, string msg, dynamic data)
        {
            this.status = status;
            this.msg = msg;
            this.data = data;
        }

        public StatusMessage(int status, string msg, dynamic data, string currentID)
        {
            this.status = status;
            this.msg = msg;
            this.data = data;
            this.currentID = currentID;
        }
    }
}
