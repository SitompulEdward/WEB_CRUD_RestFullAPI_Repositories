using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_CRUD_API.Helper
{
    public class ResponCode
    {
        public int CodeOk = 200;
        public int CodeBadRequest = 400;
        public int CodeInternalServerError = 500;
        public Object Respon(int responCode, string message, object data)
        {
            return new
            {
                status = responCode == 200 ? "SUCCESS" : "FAIL",
                responCode,
                message,
                data
            };
        }

        public string MessageGetSuccess(string msg)
        {
            return "Success Get Data " + msg;
        }

        public string MessageAddSuccess(string msg)
        {
            return "Success Add Data " + msg;
        }

        public string MessageDeleteSuccess(string msg)
        {
            return "Success Delete Data " + msg;
        }

        public string MessageEditSuccess(string msg)
        {
            return "Success Edit Data " + msg;
        }

        public string MessageDataNotFound(string msg)
        {
            return "Data " + msg + " Not Found";
        }

        public string MessageInputWrong(string msg)
        {
            return "Input Data " + msg + " Wrong";
        }

    }
}
