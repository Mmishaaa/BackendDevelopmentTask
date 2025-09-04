using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendDevelopmentTask.Migrations
{
    /// <inheritdoc />
    public partial class AddTreeNamePropToNodeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TreeName",
                table: "Nodes",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TreeName",
                table: "Nodes");
        }
    }
}
