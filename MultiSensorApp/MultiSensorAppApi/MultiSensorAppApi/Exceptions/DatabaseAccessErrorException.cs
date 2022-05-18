namespace MultiSensorAppApi.Exceptions
{
    public class DatabaseAccessErrorException : Exception
    {
        public string Origem { get; private set; }

        public DatabaseAccessErrorException(string origem)
        {
            this.Origem = origem;
        }
        public override string Message => $"An error occurred when accessing the database. Origin - {this.Origem}";
    }
}
