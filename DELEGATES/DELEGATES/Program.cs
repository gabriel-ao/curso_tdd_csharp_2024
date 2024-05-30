using static DELEGATES.Program;
using System;
using FluentValidation.Results;

namespace DELEGATES
{
    class Program
    {
        public delegate int MetodoDelegate(string nome);
        //public delegate void MetodoLambda(int idade);

        public static void UtilizaDelegate(MetodoDelegate metodoDelegate)
        {
            var letras = metodoDelegate("mary");
            Console.WriteLine("Quatidade de letras: " + letras);
        }

        public static void UtilizaDelegate2(Func<string, int> metodoDelegate2)
        {
            var letras = metodoDelegate2("mary");
            Console.WriteLine("Quatidade de letras: " + letras);
        }

        static void Main(string[] args)
        {

            #region ANONIMOS
            UtilizaDelegate(delegate (string n)
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });

            MetodoDelegate metodoDelegate = delegate (string n)
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            };

            var letras = metodoDelegate("madalena");
            Console.WriteLine("Quatidade de letras: " + letras);
            #endregion

            #region LAMBDA

            UtilizaDelegate((string n) =>
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });

            //MetodoDelegate metodoLambda = (n) => { return int.Parse(n); };
            //metodoLambda("joseroberto");

            MetodoDelegate metodoDelegate2 = (string n) =>
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            };

            var letras2 = metodoDelegate2("GABRIEL");
            Console.WriteLine("Quatidade de letras: " + letras2);


            #endregion


            #region FUNC

            UtilizaDelegate((string n) =>
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });


            Func<string, int> metodoDelegate3 = (string n) =>
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            };


            var letras3 = metodoDelegate2("NOME-FUNC");
            Console.WriteLine("Quatidade de letras: " + letras3);

            #endregion


            #region ACTION

            UtilizaDelegate((string n) =>
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });


            Action<string> metodoDelegate4 = (n) => Console.WriteLine(" Nome: " + n);
            metodoDelegate4("NOME-Action");

            #endregion



            #region PREDICATE

            UtilizaDelegate((string n) =>
            {
                Console.WriteLine(" Nome: " + n);
                return n.Length;
            });


            Predicate<int> pred = (num) => num % 2 == 0;

            Console.WriteLine("Resultado divisao: " + pred(19));

            #endregion





            #region NULLABLE

            Nullable<bool> v1 = null;
            bool? v2 = true;
            bool v3;

            if (v2.HasValue)
            {
                v3 = v2.Value;
            }
            else
            {
                v3 = false;
            }

            Console.WriteLine("Valor de v3:" + v3);

            if (v2 != null)
                v3 = v2.Value;
            else
                v3 = false;

            Console.WriteLine("Valor de v3:" + v3);

            v3 = v2.GetValueOrDefault();

            v3 = v2 ?? false;

            Console.WriteLine("Valor de v3:" + v3);


            #endregion




            #region FluentValidations

            Console.WriteLine();
            Console.WriteLine("=============================================");

            Console.WriteLine("Validando cliente ");
            Cliente cliente = new Cliente() { Nome = "" };
            ClienteValidator clienteValidator = new ClienteValidator();
            ValidationResult validationResult = clienteValidator.Validate(cliente);


            //Console.WriteLine("Resultado avalidação " + validationResult.IsValid);

            if (!validationResult.ToString().Equals(string.Empty))
                Console.WriteLine(validationResult.ToString("\n"));

            //if (!validationResult.IsValid)
            //{
            //    foreach (var erro in validationResult.Errors)
            //    {
            //        //Console.WriteLine(" Propriedade : " + erro.PropertyName + " msg: " + erro.ErrorMessage);
            //        Console.WriteLine(erro.ErrorMessage);
            //    }
            //}


            #endregion

            Console.WriteLine("F I M");
            Console.ReadKey();
        }
    }

}