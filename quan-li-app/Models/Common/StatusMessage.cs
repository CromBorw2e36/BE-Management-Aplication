namespace quan_li_app.Models.Common
{
    public class StatusMessage
    {
        public int? status { get; set; }
        public string? message { get; set; }
        public dynamic? data { get; set; }

        public StatusMessage()
        {
            this.status = 0; // Không thành công
            this.message = "";
            this.data = null;
        }

        public StatusMessage(int status, string message)
        {
            this.status = status;
            this.message = message;
            this.data = null;
        }
        public StatusMessage(int status, string message, dynamic data)
        {
            this.status = status;
            this.message = message;
            this.data = data;
        }
    }
}
