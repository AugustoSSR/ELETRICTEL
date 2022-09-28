namespace ELETRICTEL.Helper
{
    public interface IEmail
    {
        // Contrato de enviar um e-mail.
        bool Enviar(string email, string assunto, string mensagem);
    }
}
