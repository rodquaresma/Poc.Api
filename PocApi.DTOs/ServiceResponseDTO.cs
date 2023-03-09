namespace PocApi.DTOs
{
    public class ServiceResponseDTO <T>
    {
        public T Data { get; set; } = default!;
        public bool IsSucess { get; set; } = true;
        public string Message { get; set; } = default!;
    }
}
