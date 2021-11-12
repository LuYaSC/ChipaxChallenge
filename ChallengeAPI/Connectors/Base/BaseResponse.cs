using System;
using System.Collections.Generic;

namespace ChallengeAPI.Connectors.Base
{
    public class BaseResponse<BODY> where BODY : class, new()
    {
        public BaseResponse()
        {
            this.Header = new BaseHeader();
            this.Body = new BODY();
        }

        public BaseHeader Header { get; }

        public BODY Body { get; set; }

        public static BaseResponse<BODY> SetOneError(string error)
        {
            var response = new BaseResponse<BODY>();
            response.Header.SetError(new List<string>() { error });
            response.Body = null;
            return response;
        }

        public static BaseResponse<BODY> SetOk()
        {
            return SetOk(null);
        }

        public static BaseResponse<BODY> SetOk(BODY body)
        {
            var response = new BaseResponse<BODY>();
            response.Header.SetOk();
            response.Body = body;
            return response;
        }

        public void SetManyErrors(List<string> error)
        {
            this.Header.SetError(error);
            this.Body = null;
        }

        public void SetException(Exception e)
        {
            this.Header.SetException(e);
            this.Body = null;
        }
    }
}
