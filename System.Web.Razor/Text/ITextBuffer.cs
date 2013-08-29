
namespace System.Web.Razor.Text {
    public interface ITextBuffer {
        int Length { get; }
        int Position { get; set; }
        int Read();
        int Peek();
    }
}
