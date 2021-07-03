using alar.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alar.WepApi.Models.AppModels
{
    public class ResultModel<T>
    {
        public ResultModel(T _Data, ResultType _Type=ResultType.succes,  string _Message = "Başarılı")
        {
            Type = _Type;
            Data = _Data;
            RequestTime = DateTime.Now;          
            Message = _Message;
        }
        public ResultType Type { get; set; }

        public T Data { get; set; }

        public DateTime RequestTime { get; set; }

        public string Message { get; set; }
    }
}
