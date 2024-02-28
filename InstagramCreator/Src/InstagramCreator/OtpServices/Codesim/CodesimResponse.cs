namespace InstagramCreator.OtpServices.Codesim
{
    public class CodesimResponse<T> where T : class
    {
        public string? Timestamp { get; set; }
        public int? Status { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
