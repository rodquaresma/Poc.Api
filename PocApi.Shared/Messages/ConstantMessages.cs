namespace PocApi.Shared.Messages
{
    public static class ConstantMessages
    {
        public const string SucessMessage = "Operação concluída com sucesso.";
        public static string FailureMessage (string error) => $"Não foi possível concluir a operação: {error}";
    }
}