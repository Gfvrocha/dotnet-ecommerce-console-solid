﻿namespace ecommerce
{
    class Program
    {
        static void Main(string[] args)
        {
            new Cliente()
            {
                Id = 2,
                Nome = "Gustavo",
                Email = "gustavo@teste.com",
                EnderecoCompleto = "Rua teste 123 SP"
            }.Salvar();
            Console.WriteLine("O cliente foi salvo com sucesso!");
        }
    }
}