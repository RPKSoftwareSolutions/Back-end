using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ReconfigIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint("SekaniRoots_EnglishWords_Unique", "SekaniRootsEnglishWords", new string[] { "EnglishWordId", "SekaniRootId" }, null);
            migrationBuilder.AddUniqueConstraint("SekaniRoots_Topics_Unique", "SekaniRootsTopics", new string[] { "SekaniRootId", "TopicId" }, null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint("SekaniRoots_EnglishWords_Unique", "SekaniRootsEnglishWords");
            migrationBuilder.DropUniqueConstraint("SekaniRoots_Topics_Unique", "SekaniRootsTopics");
        }
    }
}
