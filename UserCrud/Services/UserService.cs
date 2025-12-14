namespace UserCrud.Services;
using UserCrud.Models;
using System.Linq;

public class UserService {
  readonly List<User> _users = [];

  public void List()
  {
    if (_users.Count == 0)
    {
      Console.WriteLine("Nenhum usuário cadastrado.");
      return;
    }
    foreach (var u in _users)
    {
      Console.WriteLine($"[{u.Id}] {u.Name} - Ativo: {u.IsActive}");
    }
  }

  private string EncryptPassword(string password)
  {
    return password; 
  }

  public void AddNewUser() {
    var user = new User{  Name = "", Password = "" };
    Console.Write("Digite o nome do usuário: ");
    var userName = Console.ReadLine();
    if (userName == null)
    {
      Console.WriteLine("É obrigatório inserir o nome do usuário.");
      return;
    }
    Console.Write("Digite a senha do usuário: ");
    var userPassword = Console.ReadLine();
    user.Id = _users.Count + 1;
    user.Name = userName;
    if (userPassword == null)
    {
      Console.WriteLine("É obrigatório inserir o nome do usuário.");
      return;
    }
    if (userPassword.Count() < 4)
    {
      Console.WriteLine("A senha deve ter ao menos 4 dígitos");
    }
    var encryptedPassword = EncryptPassword(userPassword);
    user.Password = encryptedPassword;
    _users.Add(user);
  }

  public void Delete(int id)
  {
    var user = _users.FirstOrDefault(u => u.Id == id);
    if (user == null)
    {
      Console.WriteLine($"Usuário com id '{id}' não encontrado.");
      return;
    }
    _users.Remove(user);
  }

  private String GetCurrentStatus(bool status)
  {
    if (status == true) return "Ativo";
    return "Inativo";
  }

  public void ToggleUserStatus()
  {
    Console.WriteLine("Digite o ID do usuário para alterar o status: ");
    var id = Console.ReadLine();
    if (id == null)
    {
      Console.WriteLine("É obrigatório informar um ID.");
    }
    _ = int.TryParse(id, out int idNumber);
    var user = _users.FirstOrDefault(u => u.Id == idNumber);
    if (user == null)
    {
      Console.WriteLine("Usuário não encontrado");
    } else
    {
      Console.WriteLine($"Status do usuário [{user.Id}] alterado de '{GetCurrentStatus(user.IsActive)}' para '{GetCurrentStatus(!user.IsActive)}'");
      user.IsActive = !user.IsActive;
    }
  }
}