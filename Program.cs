namespace ecommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            new Cliente()
            {
                Id = 1,
                Nome = "Felipe",
                Email = "felipe@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(Tipo.CSV);

            new Cliente()
            {
                Id = 2,
                Nome = "Gustavo",
                Email = "gustavo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar(Tipo.CSV);

            //Console.WriteLine("O cliente foi salvo com sucesso!");

            foreach (var cliente in Cliente.Todos())
            {
                Console.WriteLine("=====================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");

            }

             Console.WriteLine("=========[LENDO DO CSV]============");   
             foreach (var cliente in Cliente.Todos(Tipo.CSV))
            {
                Console.WriteLine("=====================");
                Console.WriteLine($"Id: {cliente.Id}");
                Console.WriteLine($"Nome: {cliente.Nome}");

            }
        }
    }
}