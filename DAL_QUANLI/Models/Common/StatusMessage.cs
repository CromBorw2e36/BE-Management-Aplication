namespace quan_li_app.Models.Common
{
    public class StatusMessage
    {
        public int? status { get; set; }
        public string? msg { get; set; }
        public dynamic? data { get; set; }

        public string? currentID { get; set; }

        public StatusMessage()
        {
            this.status = 0; // Không thành công
            this.msg = "";
            this.data = null;
        }

        public StatusMessage(int status, string msg)
        {
            this.status = status;
            this.msg = msg;
            this.data = null;
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
