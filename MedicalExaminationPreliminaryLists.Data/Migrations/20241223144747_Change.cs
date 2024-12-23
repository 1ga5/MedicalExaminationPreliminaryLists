using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalExaminationPreliminaryLists.Data.Migrations
{
    /// <inheritdoc />
    public partial class Change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DiagnosisCode",
                table: "DispensaryObservations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiagnosisCode",
                table: "DispensaryObservations");
        }
    }
}
