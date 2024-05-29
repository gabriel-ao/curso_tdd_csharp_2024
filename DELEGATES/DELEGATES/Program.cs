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

            Console.WriteLine("fim delegate");
            Console.ReadKey();
        }
    }

}