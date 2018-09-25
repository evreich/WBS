namespace WBS.API.Helpers
{
    public class ResponseError
    {
        public string Error { get; }
        public ResponseError(string error)
        {
            Error = error;
        }
    }
}
