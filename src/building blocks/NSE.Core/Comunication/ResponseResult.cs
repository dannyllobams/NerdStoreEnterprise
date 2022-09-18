using System.Collections.Generic;

namespace NSE.Core.Comunication
{
    public class ResponseResult
    {
        public ResponseResult()
        {
            this.Errors = new ResponseErrorMessages();
        }

        public string Title { get; set; }
        public int Status { get; set; }
        public ResponseErrorMessages Errors { get; set; }
    }

    public class ResponseErrorMessages
    {
        public ResponseErrorMessages()
        {
            this.Mensagens = new List<string>();
        }
        public List<string> Mensagens { get; set; }
    }
}
