using Compilador_22023.AnalisisLexico;
using Compilador_22023.cache;
using Compilador_22023.GestorErrores;
using Compilador_22023.TablaComponentes;

namespace Compilador_22023
{
    class Program
    {
        static void Main(string[] args)
        {
            DataCache.AgregarLinea("");
            DataCache.AgregarLinea("Segunda Línea");
            DataCache.AgregarLinea("5  3  2  1  1 1 1 1 1 1 #");

            AnalizadorLexico analex = new AnalizadorLexico();


            try
            {
                ComponenteLexico componente = analex.DevolverSiguienteComponente();

                do
                {
                    componente = analex.DevolverSiguienteComponente();
                } while (!CategoriaGramatical.FIN_ARCHIVO.Equals(componente.Categoria));

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            ImprimirComponentes(TipoComponente.SIMBOLO);
            ImprimirComponentes(TipoComponente.LITERAL);
            ImprimirComponentes(TipoComponente.DUMMY);
            ImprimirComponentes(TipoComponente.PALABRA_RESERVADA);

            ImprimirErrores(TipoError.LEXICO);
        }
        private static void ImprimirComponentes(TipoComponente tipo)
        {
            Console.WriteLine("***************INICIO*******"   +tipo.ToString()+ "      **************");

            List<ComponenteLexico> componentes = TablaMaestra.ObtenerTablaMaestra().ObtenerTodosSimbolos(tipo);
            foreach(ComponenteLexico componente in componentes)
            {
                Console.WriteLine(componente.ToString());
            }
            Console.WriteLine("**************** FIN ****" + tipo.ToString() + "  *************");
        }
        private static void ImprimirErrores(TipoError tipo)
        {
            Console.WriteLine("***************INICIO*******" + tipo.ToString() + "      **************");

            List<Error> errores = ManejadorErrores.ObtenerManejadorErrores().ObtenerErrores(tipo);
            foreach (Error error in errores)
            {
                Console.WriteLine(error.ToString());
            }
            Console.WriteLine("**************** FIN ****" + tipo.ToString() + "  *************");
        }
    }
}