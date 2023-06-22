using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBook.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addStoredProcForCoverType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROC usp_GetCoverTypes
                                      AS
                                      BEGIN
                                        SELECT * from dbo.CoverTypes
                                      END
                                     ");

            migrationBuilder.Sql(@"CREATE PROC usp_GetCoverType
                                      @Id int
                                      AS
                                      BEGIN
                                        SELECT * FROM dbo.CoverTypes 
                                        WHERE (Id = @Id)
                                      END
                                     ");

            migrationBuilder.Sql(@"CREATE PROC usp_UpdateCoverType
                                      @Id int,
                                      @Name varchar(100)
                                      AS
                                      BEGIN
                                        UPDATE dbo.CoverTypes
                                        SET Name = @Name
                                        WHERE Id = @Id
                                      END
                                     ");

            migrationBuilder.Sql(@"CREATE PROC usp_DeleteCoverType
                                      @Id int
                                      AS
                                      BEGIN
                                        DELETE FROM dbo.CoverTypes
                                        WHERE ( Id = @Id )
                                      END
                                     ");

            migrationBuilder.Sql(@"CREATE PROC usp_CreateCoverType
                                      @Name varchar(100)
                                      AS
                                      BEGIN
                                        INSERT INTO dbo.CoverTypes(Name)
                                        Values (@Name)
                                      END
                                     ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_GetCoverType");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_UpdateCoverTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_DeleteCoverTypes");
            migrationBuilder.Sql(@"DROP PROCEDURE usp_CreateCoverTypes");
        }
    }
}
