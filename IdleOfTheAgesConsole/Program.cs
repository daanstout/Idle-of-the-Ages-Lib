using HtmlAgilityPack;

namespace IdleOfTheAgesConsole;

internal class Program {
    public static void Main() {
        string html = "<div id=\"div1\" class=\"div-class\"><h1>test</h1></div?";

        HtmlDocument htmlDocument = new();
        htmlDocument.LoadHtml(html);

        var root = htmlDocument.DocumentNode;

        Console.WriteLine(root.Id);
    }
}
