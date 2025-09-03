using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendDevelopmentTask.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDeleteBehaviorNodeChildNodes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentNodeId",
                table: "Nodes");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentNodeId",
                table: "Nodes",
                column: "ParentNodeId",
                principalTable: "Nodes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nodes_Nodes_ParentNodeId",
                table: "Nodes");

            migrationBuilder.AddForeignKey(
                name: "FK_Nodes_Nodes_ParentNodeId",
                table: "Nodes",
                column: "ParentNodeId",
                principalTable: "Nodes",
                principalColumn: "Id");
        }
    }
}
