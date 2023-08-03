namespace Dept_Web_App.Models
{
    public class JsonResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public List<string> ErrorList { get; set; }
        public object Data { get; set; }   //single /list of object
    }
}
