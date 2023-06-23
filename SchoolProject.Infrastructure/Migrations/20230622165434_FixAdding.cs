using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_departments_DID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_subjects_SubID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_studentSubjects_students_StudID",
                table: "studentSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_studentSubjects_subjects_SubID",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_studentSubjects_SubID",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departmetSubjects_SubID",
                table: "departmetSubjects");

            migrationBuilder.DropColumn(
                name: "SubjectName",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DName",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "StudSubID",
                table: "studentSubjects");

            migrationBuilder.DropColumn(
                name: "DeptSubID",
                table: "departmetSubjects");

            migrationBuilder.RenameTable(
                name: "studentSubjects",
                newName: "StudentSubject");

            migrationBuilder.RenameTable(
                name: "departmetSubjects",
                newName: "DepartmetSubject");

            migrationBuilder.RenameColumn(
                name: "StudId",
                table: "students",
                newName: "StudID");

            migrationBuilder.RenameIndex(
                name: "IX_studentSubjects_StudID",
                table: "StudentSubject",
                newName: "IX_StudentSubject_StudID");

            migrationBuilder.RenameIndex(
                name: "IX_departmetSubjects_DID",
                table: "DepartmetSubject",
                newName: "IX_DepartmetSubject_DID");

            migrationBuilder.AlterColumn<int>(
                name: "Period",
                table: "subjects",
                type: "int",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "SubjectNameAr",
                table: "subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectNameEn",
                table: "subjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(18)",
                oldMaxLength: 18);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNameAr",
                table: "departments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DNameEn",
                table: "departments",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InsManager",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "grade",
                table: "StudentSubject",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject",
                columns: new[] { "SubID", "StudID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DepartmetSubject",
                table: "DepartmetSubject",
                columns: new[] { "SubID", "DID" });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ENameAr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ENameEn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_Instructor_Instructor_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructor_departments_DID",
                        column: x => x.DID,
                        principalTable: "departments",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ins_Subject",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false),
                    SubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins_Subject", x => new { x.SubId, x.InsId });
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Instructor_InsId",
                        column: x => x.InsId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ins_Subject_subjects_SubId",
                        column: x => x.SubId,
                        principalTable: "subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManager",
                table: "departments",
                column: "InsManager",
                unique: true,
                filter: "[InsManager] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subject",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DID",
                table: "Instructor",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SupervisorId",
                table: "Instructor",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments",
                column: "InsManager",
                principalTable: "Instructor",
                principalColumn: "InsId");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubject_departments_DID",
                table: "DepartmetSubject",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmetSubject_subjects_SubID",
                table: "DepartmetSubject",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_students_StudID",
                table: "StudentSubject",
                column: "StudID",
                principalTable: "students",
                principalColumn: "StudID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentSubject_subjects_SubID",
                table: "StudentSubject",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructor_InsManager",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubject_departments_DID",
                table: "DepartmetSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_DepartmetSubject_subjects_SubID",
                table: "DepartmetSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_students_StudID",
                table: "StudentSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentSubject_subjects_SubID",
                table: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Ins_Subject");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsManager",
                table: "departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentSubject",
                table: "StudentSubject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DepartmetSubject",
                table: "DepartmetSubject");

            migrationBuilder.DropColumn(
                name: "SubjectNameAr",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "SubjectNameEn",
                table: "subjects");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "students");

            migrationBuilder.DropColumn(
                name: "NameEn",
                table: "students");

            migrationBuilder.DropColumn(
                name: "DNameAr",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DNameEn",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "InsManager",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "grade",
                table: "StudentSubject");

            migrationBuilder.RenameTable(
                name: "StudentSubject",
                newName: "studentSubjects");

            migrationBuilder.RenameTable(
                name: "DepartmetSubject",
                newName: "departmetSubjects");

            migrationBuilder.RenameColumn(
                name: "StudID",
                table: "students",
                newName: "StudId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentSubject_StudID",
                table: "studentSubjects",
                newName: "IX_studentSubjects_StudID");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmetSubject_DID",
                table: "departmetSubjects",
                newName: "IX_departmetSubjects_DID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Period",
                table: "subjects",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectName",
                table: "subjects",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "students",
                type: "nvarchar(18)",
                maxLength: 18,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DName",
                table: "departments",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StudSubID",
                table: "studentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DeptSubID",
                table: "departmetSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects",
                column: "StudSubID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects",
                column: "DeptSubID");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_SubID",
                table: "studentSubjects",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_departmetSubjects_SubID",
                table: "departmetSubjects",
                column: "SubID");

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_departments_DID",
                table: "departmetSubjects",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_subjects_SubID",
                table: "departmetSubjects",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentSubjects_students_StudID",
                table: "studentSubjects",
                column: "StudID",
                principalTable: "students",
                principalColumn: "StudId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentSubjects_subjects_SubID",
                table: "studentSubjects",
                column: "SubID",
                principalTable: "subjects",
                principalColumn: "SubID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
