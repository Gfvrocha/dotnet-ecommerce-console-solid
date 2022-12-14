using System;
using ecommerce.enums;
using ecommerce.interfaces;
using Newtonsoft.Json;

namespace ecommerce.servicos
{
    class CsvServico
    {
        public static void Salvar<T>(string colunas, string arquivo, List<T> lista)
        {
            var linhas = colunas + "\n";
            foreach (var obj in lista){
                var colunasObj = "";
                foreach (var p in obj.GetType().GetProperties()){
                    colunasObj += p.GetValue(obj) + ";";
                }

                linhas += $"{colunasObj}/n";
             
            }

            File.WriteAllText(arquivo, linhas);
        }

        public static List<T> Todos<T>(string colunas, string arquivo, Type tipoObj)
        {

            if (!File.Exists(arquivo)) File.WriteAllText(arquivo, colunas);

            var lista = (List<T>)Activator.CreateInstance(typeof(List<T>));

            string text = File.ReadAllText(arquivo);
            string[] lines = text.Split(Environment.NewLine);

            foreach (string line in lines)
            {
                var coluns = line.Split(';');
                if (coluns[0].Trim().ToLower() == "Id" || coluns[0].Trim().ToLower() == "") continue;

                var obj = Activator.CreateInstance(typeof(T));
                var i = 0;
                foreach (var p in obj.GetType().GetProperties()){
                    if(p.PropertyType == typeof(int)){
                        p.SetValue(obj, int.Parse(coluns[i]));

                    }
                    else{
                         p.SetValue(obj, coluns[i]);
                    }
                    i++;
                }                

                lista.Add((T)obj);
            }
            return lista;

        }
    }


}
