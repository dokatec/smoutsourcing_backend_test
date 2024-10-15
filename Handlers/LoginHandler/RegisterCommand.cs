
public class RegisterCommand : IRequest<LoginUser>
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}
