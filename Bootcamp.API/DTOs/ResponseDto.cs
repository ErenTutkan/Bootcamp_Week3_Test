using System.Text.Json.Serialization;

namespace Bootcamp.API.DTOs
{
    public class ResponseDto<T>
    {
        public T Data { get; set; }
        public List<string> Errors { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }


        //Static Factory Design Pattern
        public static ResponseDto<T> Success(T data,int Statuscode=0)
        {
            return new ResponseDto<T> { Data = data, StatusCode= Statuscode };
        }
        public static ResponseDto<T> Success( int Statuscode=0)
        {
            return new ResponseDto<T> {Data=default(T), StatusCode = Statuscode };
        }
        public static ResponseDto<T> Fail(List<string> errors,int statusCode=0)
        {
            return new ResponseDto<T>{Data=default(T), StatusCode= statusCode,Errors=errors };
        }
        public static ResponseDto<T> Fail(string error,int statusCode)
        {
            return new ResponseDto<T> { Data=default(T), StatusCode=statusCode,Errors=new List<string> {error} };
        }
        
    }
}
