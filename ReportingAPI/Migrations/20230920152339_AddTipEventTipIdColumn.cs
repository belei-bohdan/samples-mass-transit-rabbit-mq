using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReportingAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddTipEventTipIdColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tip_id",
                table: "TipEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tip_id",
                table: "TipEvents");
        }
    }
}
