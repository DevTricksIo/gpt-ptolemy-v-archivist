using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConsoleArchivist.Migrations
{
    /// <inheritdoc />
    public partial class CreateSeedDataWithLanguagesNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Translations",
                columns: new[] { "Id", "GPTTranslationInYaml", "InGitHub", "IsToSentToGitHub", "LangTag", "Name", "Notes" },
                values: new object[,]
                {
                    { 1, null, false, false, null, "Árabe - Arab", null },
                    { 2, null, false, false, null, "Armênio - Armn", null },
                    { 3, null, false, false, null, "Assamês - Beng", null },
                    { 4, null, false, false, null, "Azeri (Latim) - Latn", null },
                    { 5, null, false, false, null, "Azeri (Cirílico) - Cyrl", null },
                    { 6, null, false, false, null, "Basco - Latn", null },
                    { 7, null, false, false, null, "Bielorrusso - Cyrl", null },
                    { 8, null, false, false, null, "Bengali - Beng", null },
                    { 9, null, false, false, null, "Búlgaro - Cyrl", null },
                    { 10, null, false, false, null, "Birmanês - Mymr", null },
                    { 11, null, false, false, null, "Catalão - Latn", null },
                    { 12, null, false, false, null, "Cherokee - Cher", null },
                    { 13, null, false, false, null, "Chinês (Simplificado) - Hans", null },
                    { 14, null, false, false, null, "Chinês (Tradicional) - Hant", null },
                    { 15, null, false, false, null, "Copta - Copt", null },
                    { 16, null, false, false, null, "Croata - Latn", null },
                    { 17, null, false, false, null, "Tcheco - Latn", null },
                    { 18, null, false, false, null, "Dinamarquês - Latn", null },
                    { 19, null, false, false, null, "Divehi - Thaa", null },
                    { 20, null, false, false, null, "Holandês - Latn", null },
                    { 21, null, false, false, null, "Inglês - Latn", null },
                    { 22, null, false, false, null, "Esperanto - Latn", null },
                    { 23, null, false, false, null, "Estoniano - Latn", null },
                    { 24, null, false, false, null, "Éwé - Latn", null },
                    { 25, null, false, false, null, "Faroês - Latn", null },
                    { 26, null, false, false, null, "Filipino - Latn", null },
                    { 27, null, false, false, null, "Finlandês - Latn", null },
                    { 28, null, false, false, null, "Francês - Latn", null },
                    { 29, null, false, false, null, "Frísio - Latn", null },
                    { 30, null, false, false, null, "Gaélico (Escocês) - Latn", null },
                    { 31, null, false, false, null, "Georgiano - Geor", null },
                    { 32, null, false, false, null, "Alemão - Latn", null },
                    { 33, null, false, false, null, "Grego - Grek", null },
                    { 34, null, false, false, null, "Groenlandês - Latn", null },
                    { 35, null, false, false, null, "Gujarati - Gujr", null },
                    { 36, null, false, false, null, "Hausa - Latn", null },
                    { 37, null, false, false, null, "Hebraico - Hebr", null },
                    { 38, null, false, false, null, "Hindi - Deva", null },
                    { 39, null, false, false, null, "Húngaro - Latn", null },
                    { 40, null, false, false, null, "Islandês - Latn", null },
                    { 41, null, false, false, null, "Igbo - Latn", null },
                    { 42, null, false, false, null, "Indonésio - Latn", null },
                    { 43, null, false, false, null, "Irlandês - Latn", null },
                    { 44, null, false, false, null, "Italiano - Latn", null },
                    { 45, null, false, false, null, "Japonês - Jpan (abrangendo Kanji, Hiragana, Katakana)", null },
                    { 46, null, false, false, null, "Javanês (Latim) - Latn", null },
                    { 47, null, false, false, null, "Kannada - Knda", null },
                    { 48, null, false, false, null, "Cazaque (Cirílico) - Cyrl", null },
                    { 49, null, false, false, null, "Cazaque (Latim) - Latn", null },
                    { 50, null, false, false, null, "Khmer - Khmr", null },
                    { 51, null, false, false, null, "Coreano - Hang", null },
                    { 52, null, false, false, null, "Curdo (Latim) - Latn", null },
                    { 53, null, false, false, null, "Quirguiz (Cirílico) - Cyrl", null },
                    { 54, null, false, false, null, "Lao - Laoo", null },
                    { 55, null, false, false, null, "Latim - Latn", null },
                    { 56, null, false, false, null, "Letão - Latn", null },
                    { 57, null, false, false, null, "Lituano - Latn", null },
                    { 58, null, false, false, null, "Macedônio - Cyrl", null },
                    { 59, null, false, false, null, "Malaiala - Mlym", null },
                    { 60, null, false, false, null, "Malaio (Latim) - Latn", null },
                    { 61, null, false, false, null, "Malaio (Árabe) - Arab", null },
                    { 62, null, false, false, null, "Maldiviano - Thaa", null },
                    { 63, null, false, false, null, "Maltês - Latn", null },
                    { 64, null, false, false, null, "Maori - Latn", null },
                    { 65, null, false, false, null, "Marathi - Deva", null },
                    { 66, null, false, false, null, "Mongol (Cirílico) - Cyrl", null },
                    { 67, null, false, false, null, "Nepalês - Deva", null },
                    { 68, null, false, false, null, "Norueguês - Latn", null },
                    { 69, null, false, false, null, "Oriya - Orya", null },
                    { 70, null, false, false, null, "Oromo - Latn", null },
                    { 71, null, false, false, null, "Pashto - Arab", null },
                    { 72, null, false, false, null, "Persa - Arab", null },
                    { 73, null, false, false, null, "Polonês - Latn", null },
                    { 74, null, false, false, null, "Português - Latn", null },
                    { 75, null, false, false, null, "Punjabi (Gurmukhi) - Guru", null },
                    { 76, null, false, false, null, "Punjabi (Árabe) - Arab", null },
                    { 77, null, false, false, null, "Romeno - Latn", null },
                    { 78, null, false, false, null, "Russo - Cyrl", null },
                    { 79, null, false, false, null, "Sânscrito - Deva", null },
                    { 80, null, false, false, null, "Sérvio (Latim) - Latn", null },
                    { 81, null, false, false, null, "Sindhi - Arab", null },
                    { 82, null, false, false, null, "Cingalês - Sinh", null },
                    { 83, null, false, false, null, "Eslovaco - Latn", null },
                    { 84, null, false, false, null, "Esloveno - Latn", null },
                    { 85, null, false, false, null, "Somali - Latn", null },
                    { 86, null, false, false, null, "Espanhol - Latn", null },
                    { 87, null, false, false, null, "Suaíli - Latn", null },
                    { 88, null, false, false, null, "Sueco - Latn", null },
                    { 89, null, false, false, null, "Tâmil - Taml", null },
                    { 90, null, false, false, null, "Tártaro (Cirílico) - Cyrl", null },
                    { 91, null, false, false, null, "Telugu - Telu", null },
                    { 92, null, false, false, null, "Tailandês - Thai", null },
                    { 93, null, false, false, null, "Tibetano - Tibt", null },
                    { 94, null, false, false, null, "Tigrinya - Ethi", null },
                    { 95, null, false, false, null, "Turco - Latn", null },
                    { 96, null, false, false, null, "Turcomano (Latim) - Latn", null },
                    { 97, null, false, false, null, "Ucraniano - Cyrl", null },
                    { 98, null, false, false, null, "Urdu - Arab", null },
                    { 99, null, false, false, null, "Uzbeque (Latim) - Latn", null },
                    { 100, null, false, false, null, "Uzbeque (Cirílico) - Cyrl", null },
                    { 101, null, false, false, null, "Vietnamita - Latn", null },
                    { 102, null, false, false, null, "Galês - Latn", null },
                    { 103, null, false, false, null, "Xhosa - Latn", null },
                    { 104, null, false, false, null, "Iídiche - Hebr", null },
                    { 105, null, false, false, null, "Iorubá - Latn", null },
                    { 106, null, false, false, null, "Zulu - Latn", null },
                    { 107, null, false, false, null, "Sérvio (Cirílico) - Cyrl", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Translations",
                keyColumn: "Id",
                keyValue: 107);
        }
    }
}
