using Microsoft.EntityFrameworkCore;
using MultiSensorAppApi.Data;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure here the data access and connection string
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("MultiSensorDBConnection")
    )
);

//try
//{
//    SqlConnectionStringBuilder connectionBuilder = new SqlConnectionStringBuilder();
//    connectionBuilder.DataSource = "multisensor9873.database.windows.net";
//    connectionBuilder.UserID = "multisensor9873";
//    connectionBuilder.Password = "Upskill2022";
//    connectionBuilder.InitialCatalog = "MultiSensorDB";

//    using (SqlConnection connection = new SqlConnection(connectionBuilder.ConnectionString))
//    {
//        Console.WriteLine("\nQuery data example:");
//        Console.WriteLine("=========================================\n");

//        String sql = "SELECT name, collation_name FROM sys.databases";

//        using (SqlCommand command = new SqlCommand(sql, connection))
//        {
//            connection.Open();
//            using (SqlDataReader reader = command.ExecuteReader())
//            {
//                while (reader.Read())
//                {
//                    Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
//                }
//            }
//        }
//    }
//}
//catch (SqlException e)
//{
//    Console.WriteLine(e.ToString());
//}
//Console.ReadLine();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
