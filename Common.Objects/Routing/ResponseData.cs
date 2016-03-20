namespace Common.Objects.Routing
{
    using System;
    using System.Collections.Generic;
    
    public class ResponseData
    {
        public ResponseData()
        {
            this.Errors = new List<string>();
        }

        public bool IsSuccessful { get; set; }
        public string StatusMessage { get; set; }
        public List<string> Errors { get; set; }
    }
}
