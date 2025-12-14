using UserCrud.Services;

var userServices = new UserService();

var _continue = true;
while (_continue == true)
{
  Console.WriteLine("CONTROLE DE USUÁRIOS");
  Console.WriteLine("--------------------");
  Console.WriteLine("Menu:");
  Console.WriteLine("---");
  Console.WriteLine("- 1. Listar usuários");
  Console.WriteLine("- 2. Adicionar usuário");
  Console.WriteLine("- 3. Ativar/desativar usuário");
  Console.WriteLine("- 4. Remover usuário");
  Console.WriteLine("- 5. Sair");
  Console.WriteLine("---");
  Console.WriteLine("Digite a opção escolhida: ");
  var option = Console.ReadLine();
  switch (option)
  {
    case "1":
      userServices.List();
      break;
    case "2":
      userServices.AddNewUser();
      break;
    case "3":
      userServices.ToggleUserStatus();
      break;
    case "4":
      userServices.Delete();
      break;
    case "5":
      _continue = false;
      break;
    default: 
      Console.WriteLine("Opção inválida. Tente novamente.");
      break;
  }
}

return 0;
