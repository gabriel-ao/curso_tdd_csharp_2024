using System;

namespace DELEGATES
{
    class Program
    {
        public delegate int MetodoDelegate(string nome);

        //public static int Qualquer(string pessoa)
        //{
        //    Console.WriteLine("Seu nome: " + pessoa);
        //    return pessoa.Length;
        //}

        public static void UtilizaDelegate(MetodoDelegate metodoDelegate)
        {
            var letras = metodoDelegate("mary");
            Console.WriteLine("Quatidade de letras: " + letras);
        }


        static void Main(string[] args)
        {
            UtilizaDelegate(delegate (string n) {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });

            MetodoDelegate metodoDelegate = delegate (string n) { 
                Console.WriteLine(" Nome: " + n); 
                return n.Length; 
            };

            var letras = metodoDelegate("madalena");
            Console.WriteLine("Quatidade de letras: " + letras);

            Console.WriteLine("fim delegate");
            Console.ReadKey();
        }
    }

}