namespace CRUDCore.Repositorios
{
    //Operaciones con ADO.NET
    public class Conexion
    {
        private string cadenaSQL = String.Empty;

        //El constructor es el primer metodo que se ejecuta al usar esta clase
        public Conexion()
        {
            //Obtener la cadena de conexion del appsettings
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builder.GetConnectionString("CadenaSQL");
        }

        //Metodo para obtener la cadena de conexion
        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}

