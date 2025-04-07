# API-USUARIOS

- Dependencias/Pacotes:

dotnet add package Microsoft.EntityFrameworkCore --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0.0
dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.0

Verifique se a CLI do EF Core está instalada
dotnet ef --version
dotnet tool install --global dotnet-ef

dotnet ef migrations add InitialCreate
dotnet ef database update

- Após adicionar a anotação [Index(IsUnique = true)], você precisará criar e aplicar uma nova migration para que a restrição de unicidade seja refletida no banco de dados:

dotnet ef migrations add AddUniqueConstraintToUserName
dotnet ef database update
